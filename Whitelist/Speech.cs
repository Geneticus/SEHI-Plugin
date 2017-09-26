using Sandbox.ModAPI;
using System.Linq;
using VRage.Plugins;
using VRage.Scripting;

namespace MSSpeech
{
    public class MSSpeech : IPlugin
    {
        bool m_bHackDone = false;

        public void Init(object gameInstance)
        {

            using (var handle = MyScriptCompiler.Static.Whitelist.OpenBatch())
            {
                handle.AllowNamespaceOfTypes(MyWhitelistTarget.ModApi,
                    typeof(System.Speech.AudioFormat.SpeechAudioFormatInfo));
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
