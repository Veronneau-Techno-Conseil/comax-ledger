using Sawtooth.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public static class ComaxLedgerHelper
    {
        public static string Hash(string identifier)=> identifier.ToByteArray().ToSha512().ToHexString();
        public static string Compress(string address, int start, int stop) => (long.Parse(address, System.Globalization.NumberStyles.HexNumber) % (stop - start) + start).ToString("X");

        public const string COMAX_FAMILY = "COMAX_FAMILY";
        public static string COMAX_FAMILY_PREFIX { get; private set; } = Hash(COMAX_FAMILY).Substring(0, 6);

        public const string ACCOUNT = "ACCOUNT";
        public const string ACCOUNT_ADDR = "00";

        public const string ASSET = "ASSET";
        public const string ASSET_ADDR = "01";

        public const string ASSET_SHARE = "ASSET_ACCESS";
        public const string ASSET_SHARE_ADDR = "02";

        public const string LICENCE = "ADDRESS";
        public const string LICENCE_ADDR = "0F";

    }
}
