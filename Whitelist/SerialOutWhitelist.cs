using Sandbox.ModAPI;
using System.Linq;
using VRage.Plugins;
using VRage.Scripting;
using VRage.Game.ModAPI;


namespace Serial.IO
{
    public class Arduino : IPlugin
    {
        bool m_bHackDone = false;
        private MyScriptWhitelist _whitelist;
        public void Init(object gameInstance)
        {
            _whitelist = MyScriptCompiler.Static.Whitelist;            
            MyScriptCompiler.Static.AddReferencedAssemblies(typeof(IMySerialOutAccess).Assembly.Location);
            MyScriptCompiler.Static.AddImplicitIngameNamespacesFromTypes(typeof(IMySerialOutAccess));

            using (var handle = MyScriptCompiler.Static.Whitelist.OpenBatch())
            {
                handle.AllowNamespaceOfTypes(MyWhitelistTarget.Ingame,
                    typeof(VRage.Game.ModAPI.Ingame.IMySerialOutAccess));
                handle.AllowNamespaceOfTypes(MyWhitelistTarget.ModApi,
                    typeof(VRage.Game.ModAPI.IMySerialOutAccess));
            }
            MyScriptCompiler.Static.AddConditionalCompilationSymbols("EXTRA_WHITELIST");
            return;
        }

        public void Update()
        {
            if (!m_bHackDone)
            {
                m_bHackDone = true;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SkinHack() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
