using System;

namespace AoC2020
{
    public static class Day12
    {
        public static int Task12_2(string[] input)
        {
            var curX = 0;
            var curY = 0;
            var wayPointX = 10;
            var wayPointY = 1;
            
            foreach (var com in input)
            {
                var letter = com[0];
                var number = Convert.ToInt32(com.Substring(1, com.Length - 1));
                
                switch (letter)
                {
                    case 'N':
                        wayPointY += number;
                        break;
                    case 'S':
                        wayPointY -= number;
                        break;
                    case 'E':
                        wayPointX += number;
                        break;
                    case 'W':
                        wayPointX -= number;
                        break;
                    case 'L':
                        var normalized = number % 360;
                        switch (normalized)
                        {
                            case 0:
                                break;
                            case 90:
                                var oldX = wayPointX;
                                var oldY = wayPointY;
                                wayPointX = (-1) * oldY;
                                wayPointY = oldX;
                                break;
                            case 180:
                                oldX = wayPointX;
                                oldY = wayPointY;
                                wayPointX = (-1) * oldX;
                                wayPointY = (-1) * oldY;
                                break;
                            case 270:
                                oldX = wayPointX;
                                oldY = wayPointY;
                                wayPointX = oldY;
                                wayPointY = (-1) * oldX;
                                break;
                            default:
                                throw new Exception("Incorrect angle");
                        }
                        break;
                    case 'R':
                        normalized = number % 360;
                        switch (normalized)
                        {
                            case 0:
                                break;
                            case 90:
                                var oldX = wayPointX;
                                var oldY = wayPointY;
                                wayPointX = oldY;
                                wayPointY = (-1) * oldX;
                                break;
                            case 180:
                                oldX = wayPointX;
                                oldY = wayPointY;
                                wayPointX = (-1) * oldX;
                                wayPointY = (-1) * oldY;
                                break;
                            case 270:
                                oldX = wayPointX;
                                oldY = wayPointY;
                                wayPointX = (-1) * oldY;
                                wayPointY = oldX;
                                break;
                            default:
                                throw new Exception("Incorrect angle");
                        }
                        break;
                    case 'F':
                        curX += number * wayPointX;                        
                        curY += number * wayPointY;                        
                        break;
                    default:
                        throw new Exception("Incorrect letter");
                }
            }

            return Math.Abs(curX) + Math.Abs(curY);
        }

        public static int Task12_1(string[] input)
        {
            var curX = 0;
            var curY = 0;
            var curFacing = 0;//east, to south - positive
            
            foreach (var com in input)
            {
                var letter = com[0];
                var number = Convert.ToInt32(com.Substring(1, com.Length - 1));
                
                switch (letter)
                {
                    case 'N':
                        curY += number;
                        break;
                    case 'S':
                        curY -= number;
                        break;
                    case 'E':
                        curX += number;
                        break;
                    case 'W':
                        curX -= number;
                        break;
                    case 'L':
                        curFacing -= number;
                        break;
                    case 'R':
                        curFacing += number;
                        break;
                    case 'F':
                        curFacing %= 360;
                        switch (curFacing)
                        {
                            case 0:
                                curX += number;
                                break;
                            case 90:
                            case -270:
                                curY -= number;
                                break;
                            case 180:
                            case -180:
                                curX -= number;
                                break;
                            case 270:
                            case -90:
                                curY += number;
                                break;
                            default:
                                throw new Exception("Incorrect angle");
                        }
                        break;
                    default:
                        throw new Exception("Incorrect letter");
                }
            }

            return Math.Abs(curX) + Math.Abs(curY);
        }
    }
}