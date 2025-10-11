public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        //If the value already exists
        //We return so no insertion is performed
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        //Check if the current node matches
        if (value == Data)
        {
            return true;
        }
        //If the value is less than the current note
        //We enter the left branch
        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        //If the value is greater than the current node
        //We enter the right branch
        else
        {
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        //Starting getting the height from the left
        //We check if the node is null, if null, return 0
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        //We grab the greatest value from the both branches
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}