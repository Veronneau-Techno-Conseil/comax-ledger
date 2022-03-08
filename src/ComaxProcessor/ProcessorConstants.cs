using Sawtooth.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public static class ProcessorConstants
    {
        public const string COMAX_FAMILY = "COMAX_FAMILY";
        public static string COMAX_FAMILY_PREFIX { get; private set; } = COMAX_FAMILY.ToByteArray().ToSha512().ToHexString().Substring(0, 6);

    }
}
