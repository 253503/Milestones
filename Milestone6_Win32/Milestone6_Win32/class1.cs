using System.Runtime.InteropServices;

namespace Milestone6_Win32
{
    internal class class1
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(int exStyle, string className, string windowName
            , int style, int x, int u, int width, int height, IntPtr hwdParent, IntPtr hMenu, IntPtr hIntance, IntPtr lpParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        static void Main(string[] args)
        {
            int result = MessageBox(IntPtr.Zero, "I am a test asdasd", "Heading some dummy text", 2);

            if (result == 1)
            {
                Console.WriteLine("I am clicked");
            }
            if (result == 2)
            {
                Console.WriteLine("I am clicked on cancel");
            }
            const int WS_CHILD = 0x40000000;
            const int WS_VISIBLE = 0x10000000;
            const int BS_PUSHBUTTON = 0x00000001;
            IntPtr hwndParent = IntPtr.Zero;
            IntPtr hInstance = GetModuleHandle(null);

            //create a button control
            IntPtr buttonHandle = CreateWindowEx(0, "Button", "Click Me", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 10, 10, 100, 50, hwndParent, IntPtr.Zero, hInstance, IntPtr.Zero);


        }
    }
}