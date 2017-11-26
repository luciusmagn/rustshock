using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TerrariaApi.Server;
using TShockAPI;
using Terraria;
using RGiesecke.DllExport;

namespace RustShock
{
	[ApiVersion(2,1)]
    public class RustShock : TerrariaPlugin
    {
        public delegate void BasicCommand();
        public delegate void RegisterCallback(string s, BasicCommand cb);

		public RustShock(Main game) : base(game) {}

		[DllImport("rust_shock.dll", CallingConvention = CallingConvention.Cdecl)]
		public extern static void rusting();

        [DllImport("rust_shock.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void get_cmd_register(RegisterCallback cb);

        public override void Initialize() {
            rusting();
            get_cmd_register((s, cb) => Commands.ChatCommands.Add(new Command((_) => cb(), s)));
        }
        public override string Author => "magnusi";
        public override string Name => "RustShock";
    }
}
