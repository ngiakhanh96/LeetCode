namespace ConsoleApp1.Stack;

[LastVisited(2023, 08, 17)]
public class _232
{
    public class MyQueue
    {

        private Stack<int> leftStack = new Stack<int>(100);
        private Stack<int> rightStack = new Stack<int>(100);
        public MyQueue()
        {

        }

        public void Push(int x)
        {
            leftStack.Push(x);
        }

        public int Pop()
        {
            if (rightStack.Count > 0)
            {
                return rightStack.Pop();
            }
            while (leftStack.Count > 0)
            {
                rightStack.Push(leftStack.Pop());
            }
            return rightStack.Pop();
        }

        public int Peek()
        {
            if (rightStack.Count > 0)
            {
                return rightStack.Peek();
            }
            while (leftStack.Count > 0)
            {
                rightStack.Push(leftStack.Pop());
            }
            return rightStack.Peek();
        }

        public bool Empty()
        {
            return leftStack.Count + rightStack.Count == 0;
        }
    }
}