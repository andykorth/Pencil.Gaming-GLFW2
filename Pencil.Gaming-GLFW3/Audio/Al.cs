// License: ../LICENSE.TXT

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pencil.Gaming.Audio {
    public static partial class Al {
        public static class Alc {
            private static IntPtr alcDeviceHandle;
            private static IntPtr alcContextHandle;

            private delegate bool CloseDevice(IntPtr hndl);
            private delegate IntPtr OpenDevice(string str);
            private delegate bool IsExtensionPresent(IntPtr hndl,string extnsn);
            private delegate void GetIntegerv(IntPtr hndl,int @int,int count,int[] @out);
            private delegate IntPtr CreateContext(IntPtr hndl,int[] attribs);
            private delegate bool MakeContextCurrent(IntPtr hndl);

            internal static void Init() {
#if DEBUG
                Stopwatch sw = new Stopwatch();
                sw.Start();
#endif
                CloseDevice alcCloseDevice = null;
                OpenDevice alcOpenDevice = null;
                IsExtensionPresent alcIsExtensionPresent = null;
                GetIntegerv alcGetIntegerv = null;
                CreateContext alcCreateContext = null;
                MakeContextCurrent alcMakeContextCurrent = null;

                if (Environment.Is64BitProcess) {
                    alcCloseDevice = Alc64.alcCloseDevice;
                    alcOpenDevice = Alc64.alcOpenDevice;
                    alcIsExtensionPresent = Alc64.alcIsExtensionPresent;
                    alcGetIntegerv = Alc64.alcGetIntegerv;
                    alcCreateContext = Alc64.alcCreateContext;
                    alcMakeContextCurrent = Alc64.alcMakeContextCurrent;
                } else {
                    alcCloseDevice = Alc32.alcCloseDevice;
                    alcOpenDevice = Alc32.alcOpenDevice;
                    alcIsExtensionPresent = Alc32.alcIsExtensionPresent;
                    alcGetIntegerv = Alc32.alcGetIntegerv;
                    alcCreateContext = Alc32.alcCreateContext;
                    alcMakeContextCurrent = Alc32.alcMakeContextCurrent;
                }

                alcDeviceHandle = alcOpenDevice(null);
                if (alcDeviceHandle == IntPtr.Zero) {
                    // TODO: Named devices
                    throw new Exception("Could not find audio device.");
                }

                List<int> attributes = new List<int> { 4105, 0, };
                if (alcIsExtensionPresent(alcDeviceHandle, "ALC_EXT_EFX")) {
                    int[] alcInteger = new int[1];
                    alcGetIntegerv(alcDeviceHandle, 131065, 1, alcInteger);
                    attributes.Add(131065);
                    attributes.Add(alcInteger[0]);
                }
                attributes.Add(0);

                alcContextHandle = alcCreateContext(alcDeviceHandle, attributes.ToArray());

                if (alcContextHandle == IntPtr.Zero) {
                    alcCloseDevice(alcDeviceHandle);
                    throw new Exception("Failed to create ALC context.");
                }

                alcMakeContextCurrent(alcContextHandle);

#if DEBUG
                sw.Stop();
                Console.WriteLine("Initializing ALC took {0} milliseconds.", sw.ElapsedMilliseconds);
#endif
            }
            public static void Terminate() {
                if (Environment.Is64BitProcess) {
                    Alc64.alcCloseDevice(alcDeviceHandle);
                } else {
                    Alc32.alcCloseDevice(alcDeviceHandle);
                }
            }
        }

        static Al() {
            Alc.Init();
        }

        public static void Enable(AlCapability capability) {
            AlDelegates.alEnable((int) capability);
        }
        public static void Disable(AlCapability capability) {
            AlDelegates.alDisable((int) capability);
        } 
        public static bool IsEnabled(AlCapability capability) {
            return AlDelegates.alIsEnabled((int) capability);
        } 
        public static unsafe string GetString(AlGetString param) {
            sbyte * bptr = AlDelegates.alGetString((int) param);
            return new string(bptr);
        }
        public static void GetBoolean(AlGetInteger param, bool[] data) {
            AlDelegates.alGetBooleanv((int) param, data);
        }
        public static void GetInteger(AlGetInteger param, int[] data) {
            AlDelegates.alGetIntegerv((int) param, data);
        }
        public static void GetFloat(AlGetFloat param, float[] data) {
            AlDelegates.alGetFloatv((int) param, data);
        }
//        public static void GetDouble(int param, double[] data) {
//            AlDelegates.alGetDoublev(param, data);
//        }
        public static bool GetBoolean(AlGetInteger param) {
            return AlDelegates.alGetBoolean((int) param);
        }
        public static int GetInteger(AlGetInteger param) {
            return AlDelegates.alGetInteger((int) param);
        }
        public static float GetFloat(AlGetFloat param) {
            return AlDelegates.alGetFloat((int) param);
        }
        public static double GetDouble(int param) {
            return AlDelegates.alGetDouble(param);
        }
        public static int GetError() {
            return AlDelegates.alGetError();
        }
        public static bool IsExtensionPresent(string extname) {
            return AlDelegates.alIsExtensionPresent(extname);
        }
        public static IntPtr GetProcAddress(string fname) {
            return AlDelegates.alGetProcAddress(fname);
        }
        public static int GetEnumValue(string ename) {
            return AlDelegates.alGetEnumValue(ename);
        }
        public static void Listener(AlListenerf param, float value) {
            AlDelegates.alListenerf((int) param, value);
        }
        public static void Listener(AlListener3f param, float value1, float value2, float value3) {
            AlDelegates.alListener3f((int) param, value1, value2, value3);
        }
        public static void Listener(AlListenerfv param, float[] values) {
            AlDelegates.alListenerfv((int) param, values);
        } 
//        public static void Listener(int param, int value) {
//            AlDelegates.alListeneri(param, value);
//        }
//        public static void Listener(int param, int value1, int value2, int value3) {
//            AlDelegates.alListener3i(param, value1, value2, value3);
//        }
//        public static void Listener(int param, int[] values) {
//            AlDelegates.alListeneriv(param, values);
//        }
        public static void GetListener(AlListenerf param, out float value) {
            AlDelegates.alGetListenerf((int) param, out value);
        }
        public static void GetListener(AlListener3f param, out float value1, out float value2, out float value3) {
            AlDelegates.alGetListener3f((int) param, out value1, out value2, out value3);
        }
        public static void GetListener(AlListenerfv param, float[] values) {
            AlDelegates.alGetListenerfv((int) param, values);
        }
//        public static void GetListener(int param, out int value) {
//            AlDelegates.alGetListeneri(param, out value);
//        }
//        public static void GetListener(int param, out int value1, out int value2, out int value3) {
//            AlDelegates.alGetListener3i(param, out value1, out value2, out value3);
//        }
//        public static void GetListener(int param, int[] values) {
//            AlDelegates.alGetListeneriv(param, values);
//        }
        public static void GenSources(int n, uint[] sources) {
            AlDelegates.alGenSources(n, sources);
        } 
        public static void GenSources(int n, out uint source) {
            AlDelegates.alGenSource(n, out source);
        }
        public static void DeleteSources(int n, uint[] sources) {
            AlDelegates.alDeleteSources(n, sources);
        }
        public static void DeleteSources(int n, ref uint source) {
            AlDelegates.alDeleteSource(n, ref source);
        }
        public static bool IsSource(uint sid) {
            return AlDelegates.alIsSource(sid);
        } 
        public static void Source(uint sid, AlSourcef param, float value) {
            AlDelegates.alSourcef(sid, (int) param, value);
        } 
        public static void Source(uint sid, AlSource3f param, float value1, float value2, float value3) {
            AlDelegates.alSource3f(sid, (int) param, value1, value2, value3);
        }
//        public static void Source(uint sid, int param, float[] values) {
//            AlDelegates.alSourcefv(sid, param, values);
//        } 
        public static void Source(uint sid, AlSourcei param, int value) {
            AlDelegates.alSourcei(sid, (int) param, value);
        } 
        public static void Source(uint sid, AlSource3i param, int value1, int value2, int value3) {
            AlDelegates.alSource3i(sid, (int) param, value1, value2, value3);
        }
        public static void Source(uint sid, AlSourceb param, bool value) {
            AlDelegates.alSourcei(sid, (int) param, value ? 1 : 0);
        }
//        public static void Source(uint sid, int param, int[] values) {
//            AlDelegates.alSourceiv(sid, param, values);
//        }
        public static void GetSource(uint sid, AlSourcef param, out float value) {
            AlDelegates.alGetSourcef(sid, (int) param, out value);
        }
        public static void GetSource(uint sid, AlSource3f param, out float value1, out float value2, out float value3) {
            AlDelegates.alGetSource3f(sid, (int) param, out value1, out value2, out value3);
        }
//        public static void GetSource(uint sid, int param, float[] values) {
//            AlDelegates.alGetSourcefv(sid, param, values);
//        }
        public static void GetSource(uint sid, AlSourcei param, out int value) {
            AlDelegates.alGetSourcei(sid, (int) param, out value);
        }
        public static void GetSource(uint sid, AlSource3i param, out int value1, out int value2, out int value3) {
            AlDelegates.alGetSource3i(sid, (int) param, out value1, out value2, out value3);
        }
        public static void GetSource(uint sid, AlSourceb param, out bool value) {
            int ivalue;
            AlDelegates.alGetSourcei(sid, (int) param, out ivalue);
            value = (ivalue != 0);
        }
//        public static void GetSource(uint sid, int param, int[] values) {
//            AlDelegates.alGetSourceiv(sid, param, values);
//        }
        public static void SourcePlay(int ns, uint[]sids) {
            AlDelegates.alSourcePlayv(ns, sids);
        }
        public static void SourceStop(int ns, uint[]sids) {
            AlDelegates.alSourceStopv(ns, sids);
        }
        public static void SourceRewind(int ns, uint[]sids) {
            AlDelegates.alSourceRewindv(ns, sids);
        }
        public static void SourcePause(int ns, uint[]sids) {
            AlDelegates.alSourcePausev(ns, sids);
        }
        public static void SourcePlay(uint sid) {
            AlDelegates.alSourcePlay(sid);
        }
        public static void SourceStop(uint sid) {
            AlDelegates.alSourceStop(sid);
        }
        public static void SourceRewind(uint sid) {
            AlDelegates.alSourceRewind(sid);
        }
        public static void SourcePause(uint sid) {
            AlDelegates.alSourcePause(sid);
        }
        public static void SourceQueueBuffers(uint sid, int numEntries, uint[]bids) {
            AlDelegates.alSourceQueueBuffers(sid, numEntries, bids);
        }
        public static void SourceUnqueueBuffers(uint sid, int numEntries, uint[]bids) {
            AlDelegates.alSourceUnqueueBuffers(sid, numEntries, bids);
        }
        public static void GenBuffers(int n, uint[] buffers) {
            AlDelegates.alGenBuffers(n, buffers);
        }
        public static void GenBuffers(int n, out uint buffer) {
            AlDelegates.alGenBuffer(n, out buffer);
        }
        public static void DeleteBuffers(int n, uint[] buffers) {
            AlDelegates.alDeleteBuffers(n, buffers);
        }
        public static void DeleteBuffers(int n, ref uint buffer) {
            AlDelegates.alDeleteBuffer(n, ref buffer);
        }
        public static bool IsBuffer(uint bid) {
            return AlDelegates.alIsBuffer(bid);
        }
        public static void BufferData(uint bid, AlFormat format, IntPtr data, int size, int freq) {
            AlDelegates.alBufferData(bid, (int) format, data, size, freq);
        }
//        public static void Buffer(uint bid, int param, float value) {
//            AlDelegates.alBufferf(bid, param, value);
//        }
//        public static void Buffer(uint bid, int param, float value1, float value2, float value3) {
//            AlDelegates.alBuffer3f(bid, param, value1, value2, value3);
//        }
//        public static void Buffer(uint bid, int param, float[] values) {
//            AlDelegates.alBufferfv(bid, param, values);
//        }
//        public static void Buffer(uint bid, int param, int value) {
//            AlDelegates.alBufferi(bid, param, value);
//        }
//        public static void Buffer(uint bid, int param, int value1, int value2, int value3) {
//            AlDelegates.alBuffer3i(bid, param, value1, value2, value3);
//        }
//        public static void Buffer(uint bid, int param, int[] values) {
//            AlDelegates.alBufferiv(bid, param, values);
//        }
//        public static void GetBuffer(uint bid, int param, out float value) {
//            AlDelegates.alGetBufferf(bid, param, out value);
//        }
//        public static void GetBuffer(uint bid, int param, out float value1, out float value2, out float value3) {
//            AlDelegates.alGetBuffer3f(bid, param, out value1, out value2, out value3);
//        }
//        public static void GetBuffer(uint bid, int param, float[] values) {
//            AlDelegates.alGetBufferfv(bid, param, values);
//        }
        public static void GetBuffer(uint bid, AlGetBufferi param, out int value) {
            AlDelegates.alGetBufferi(bid, (int) param, out value);
        }
//        public static void GetBuffer(uint bid, int param, out int value1, out int value2, out int value3) {
//            AlDelegates.alGetBuffer3i(bid, param, out value1, out value2, out value3);
//        }
//        public static void GetBuffer(uint bid, int param, int[] values) {
//            AlDelegates.alGetBufferiv(bid, param, values);
//        }
        public static void DopplerFactor(float value) {
            AlDelegates.alDopplerFactor(value);
        }
        public static void DopplerVelocity(float value) {
            AlDelegates.alDopplerVelocity(value);
        }
        public static void SpeedOfSound(float value) {
            AlDelegates.alSpeedOfSound(value);
        }
        public static void DistanceModel(int distanceModel) {
            AlDelegates.alDistanceModel(distanceModel);
        }
    }
}