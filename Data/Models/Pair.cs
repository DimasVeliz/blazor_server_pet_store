namespace BlazorServerDemo.Data;
public class Pair
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Pair(int row,int col)
    {
        Row = row;
        Col = col;
    }
    public override bool Equals(object? obj)
    {
        Pair? other = obj as Pair;
        if(other is  null)
            return false;
        return this.Row ==other.Row && this.Col==other.Col;
    }
}