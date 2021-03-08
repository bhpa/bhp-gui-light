using Bhp.Network.P2P.Payloads;
using Bhp.Properties;
using Bhp.Server;
using Bhp.VM;
using Bhp.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using VMArray = Bhp.VM.Types.Array;

namespace Bhp.UI
{
    public partial class MappingAssetDialog : Form
    {
        WalletTransaction walletTransaction = new WalletTransaction();
        string bhpAssetId = "0x13f76fabfe19f3ec7fd54d63179a156bafc44afc53a7f07a7a15f6724c0aa854";
        public MappingAssetDialog(WalletAssetDescriptor asset = null, UInt160 scriptHash = null)
        {
            InitializeComponent();
            if (asset == null)
            {
                foreach (var balance in Program.MainForm.CurrentBalances)
                {
                    if (balance.Key == UInt256.Parse(bhpAssetId))
                    {
                        comboBox1.Items.Add(new WalletAssetDescriptor(balance.Key));
                    }
                }
                foreach (string s in Settings.Default.BRC20Watched)
                {
                    UInt160 asset_id = UInt160.Parse(s);
                    try
                    {
                        if (asset_id == UInt160.Parse(bhpAssetId))
                        {
                            comboBox1.Items.Add(new WalletAssetDescriptor(asset_id));
                        }
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }
            }
            else
            {
                comboBox1.Items.Add(asset);
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is WalletAssetDescriptor asset)
            {
                textBox3.Text = Program.MainForm.CurrentBalances[(UInt256)asset.AssetId].ToString();
            }
            else
            {
                textBox3.Text = "";
            }
            textBox_TextChanged(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mappingAddress = textBox1.Text.Trim();
            if (mappingAddress.Length != 40 && mappingAddress.Length != 42) {
                MessageBox.Show("映射地址格式错误！");
                return;
            }
            if (mappingAddress.Length == 42 && mappingAddress.Substring(0, 2).ToLower() != "0x")
            {
                MessageBox.Show("映射地址格式错误！");
                return;
            }
            if (mappingAddress.Length == 40) 
            {
                mappingAddress = "0x" + mappingAddress;
            }
            string message = string.Format("映射地址：{0} \r\n映射金额：{1} \r\n注意：请仔细检查映射地址，映射地址填写错误将导致资产丢失！！！", mappingAddress, textBox2.Text.Trim());

            if (MessageBox.Show(message, "请确认验证地址", MessageBoxButtons.OKCancel) == DialogResult.OK) 
            {
                this.DialogResult = DialogResult.OK;
            }
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 || textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                button1.Enabled = false;
                return;
            }
            WalletAssetDescriptor asset = (WalletAssetDescriptor)comboBox1.SelectedItem;
            if (!BigDecimal.TryParse(textBox2.Text.Trim(), asset.Decimals, out BigDecimal amount))
            {
                button1.Enabled = false;
                return;
            }
            if (amount.Sign <= 0)
            {
                button1.Enabled = false;
                return;
            }
            button1.Enabled = true;
        }

        public Transaction GetTransaction(out List<string> inputAddress)
        {
            inputAddress = new List<string>();
            string toadddress = "AUU43MRKo754iJn4G4HStLTrpy94X7APtr";//归集地址
            UInt160 ChangeAddress = null;

            Transaction tx = new ContractTransaction();
            List<TransactionAttribute> attributes = new List<TransactionAttribute>();


            UInt160 fromAddress = null;

            HashSet<UInt160> sAttributes = new HashSet<UInt160>();
            attributes.AddRange(sAttributes.Select(p => new TransactionAttribute
            {
                Usage = TransactionAttributeUsage.Script,
                Data = p.ToArray()
            }));
            string remark = textBox1.Text.Trim();  //此处为bhp2.0的地址
            if (remark.Length == 40)
            {
                remark = "0x" + remark;
            }


            attributes.Add(new TransactionAttribute
            {
                Usage = TransactionAttributeUsage.Remark,
                Data = Encoding.UTF8.GetBytes(remark)
            }
            );
            tx.Attributes = attributes.ToArray();
            WalletAssetDescriptor asset = (WalletAssetDescriptor)comboBox1.SelectedItem;


            TransactionOutput transactionOutput = new TransactionOutput();
            transactionOutput.AssetId = (UInt256)asset.AssetId;
            transactionOutput.ScriptHash = toadddress.ToScriptHash();
            transactionOutput.Value = Fixed8.Parse(textBox2.Text.Trim());
            TransactionOutput[] transactionOutputs = new TransactionOutput[1];
            transactionOutputs[0] = transactionOutput;
            tx.Outputs = transactionOutputs;
            tx.Witnesses = new Witness[0];
            if (tx is ContractTransaction ctx)
                tx = walletTransaction.MakeTransaction(Program.CurrentWallet, ctx, out inputAddress, from: fromAddress, change_address: ChangeAddress);
            return tx;

        }

        //解析remark
        public void explainRemark() 
        {
            string remarkCode = "307845413637346664446537313466643937396465334564463046353641413937313642383938656338";
            string remark = Encoding.UTF8.GetString(Bhp.Helper.HexToBytes(remarkCode));
            MessageBox.Show(remark);
        }
    }

 
}
