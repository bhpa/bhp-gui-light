﻿using Bhp.Ledger;
using Bhp.SmartContract;
using Bhp.VM;
using System;

namespace Bhp.Server
{
    public class WalletAssetDescriptor
    {
        public UIntBase AssetId;
        public string AssetName;
        public byte Decimals;

        public WalletAssetDescriptor(UIntBase asset_id)
        {
            if (asset_id is UInt160 asset_id_160)
            {
                byte[] script;
                using (ScriptBuilder sb = new ScriptBuilder())
                {
                    sb.EmitAppCall(asset_id_160, "decimals");
                    sb.EmitAppCall(asset_id_160, "name");
                    script = sb.ToArray();
                }
                using (ApplicationEngine engine = ApplicationEngine.Run(script))
                {
                    if (engine.State.HasFlag(VMState.FAULT)) throw new ArgumentException();
                    this.AssetId = asset_id;
                    this.AssetName = engine.ResultStack.Pop().GetString();
                    this.Decimals = (byte)engine.ResultStack.Pop().GetBigInteger();
                }
            }
            else
            {
                AssetState state = Program.MainForm.CurrentAssets[(UInt256)asset_id];
                this.AssetId = state.AssetId;
                this.AssetName = state.GetName();
                this.Decimals = state.Precision;
            }
        }

        public override string ToString()
        {
            return AssetName;
        }
    }
}
