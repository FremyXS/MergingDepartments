

using MergingDepartmentsConsole;
using static MergingDepartments;

Console.WriteLine(MergingDepartments.GetFinishedSquare(new Room(6, 6, 8, 8), new Room(1, 8, 4, 9)));

public static class MergingDepartments
{
    private static int ComparisonPointsMax(int val1, int val2)
    {
        if (val1 > val2)
            return val1;
        return val2;
    }
    private static int ComparisonPointsMin(int val1, int val2)
    {
        if (val1 < val2)
            return val1;
        return val2;
    }
    private static Room GetNewRoom(Room room_first, Room room_second)
        => new Room
            (
                ComparisonPointsMin(room_first.x1, room_second.x1),
                ComparisonPointsMin(room_first.y1, room_second.y1),
                ComparisonPointsMax(room_first.x2, room_second.x2),
                ComparisonPointsMax(room_first.y2, room_second.y2)
            );
    public static int GetFinishedSquare(Room room_first, Room room_second)
    { 
        var new_room = GetNewRoom(room_first, room_second);
        new_room.TransformationIntoArea();
        return new_room.GetSquare();
    }

    public class Room
    {
        protected internal int x1;
        protected internal int y1;
        protected internal int x2;
        protected internal int y2;
        public Room(int x1, int y1, int x2, int y2)
        {
            this.x1 = CheckCoor(x1);
            this.y1 = CheckCoor(y1);
            this.x2 = CheckCoor(x2);
            this.y2 = CheckCoor(y2);
        }
        private int CheckCoor(int value)
        {
            if (value < 0 || value > 10)
                throw new RoomException("Value greater than 10", value);

            return value;
        }
        public void TransformationIntoArea()
        {            
            var x_axis = this.x2 - this.x1;
            var y_axis = this.y2 - this.y1;

            if (x_axis == y_axis)
                return;

            if (x_axis > y_axis)
                this.y2 += x_axis - y_axis;
            else
                this.x2 += y_axis - x_axis;
        }
        public int GetSquare()
            => (this.x2 - this.x1) * (this.y2 - this.y1);
    }
}