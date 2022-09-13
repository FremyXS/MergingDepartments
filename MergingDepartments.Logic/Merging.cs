using System.Runtime.InteropServices;

namespace MergingDepartments.Logic
{
    public static class Merging
    {
        private static Room GetNewRoom(Room[] rooms)
            => new Room
                (
                    rooms.Min(el => el.GetMinX()),
                    rooms.Min(el => el.GetMinY()),
                    rooms.Max(el => el.GetMaxX()),
                    rooms.Max(el => el.GetMaxY())
                );
        public static int GetFinishedSquare(params Room[] rooms)
        {
            Room.CheckingIntersectionCoordinates(rooms);
            var new_room = GetNewRoom(rooms);
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
                    throw new RoomException("Value greater than 10 or less 0", value);

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
            public int GetMinX()
                => x1 > x2 ? x2 : x1;
            public int GetMinY()
                => y1 > y2 ? y2 : y1;
            public int GetMaxX()
                => x1 < x2 ? x2 : x1;
            public int GetMaxY()
                => y1 < y2 ? y2 : y1;

            public static void CheckingIntersectionCoordinates(Room[] rooms)
            {
                for(var i = 0; i < rooms.Length - 1; i++)
                {
                    for(var j = i + 1; j < rooms.Length; j++)
                    {
                        if (rooms[i].y1 >= rooms[j].y1 && rooms[i].y1 <= rooms[j].y2)
                            throw new RoomException("Value greater than 10 or less 0", rooms[i].y1);
                        if (rooms[i].x1 >= rooms[j].x1 && rooms[i].x1 <= rooms[j].x2)
                            throw new RoomException("Value greater than 10 or less 0", rooms[i].x1);
                        if (rooms[i].y2 >= rooms[j].y1 && rooms[i].y2 <= rooms[j].y2)
                            throw new RoomException("Value greater than 10 or less 0", rooms[i].y2);
                        if (rooms[i].x2 >= rooms[j].x1 && rooms[i].x2 <= rooms[j].x2)
                            throw new RoomException("Value greater than 10 or less 0", rooms[i].x2);
                    }
                }
            }
        }
    }
}