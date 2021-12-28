using System;
using System.Collections.Generic;

/*
    Unes String vortex space seperated valunera galis orinak : "1 DUP POP + -"
    u unes stack
    String@ commander en
        1) ete tiva add es anum stack
        2) DUP - stackum add es anum stacki top most elementi duplicate-@
        3) POP Stacki top element@ jnjum es
        4) + hanum es Stacki verevi 2 elementner@ u het es dnum iranc gumar@
        5) - hanum es stacki verevi 2 elementner@ u het es dnum Top1 - Top2
    Stack-@ naxatesvaca 0-2^10 tveri rangei hamar,
    ete gorcoxutyunneri ardyunqum stacvac tiv@ es rangeic ancnuma, kam ete stacki exac state-@ chi toxum gorcoxutyun anes return es anum error (-1 xndri paymannerov)
    ete gorcoxutyunnern aneluc heto stack-@ datarka return es anum error (-1) ete che top element@
*/

namespace StackCommander
{
    public class Solution
    {
        public int StackCommander(string commandText)
        {
            Stack<int> numbers = new Stack<int>();
            string[] commands = commandText.ToLower().Split(' ');

            try
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    switch (commands[i])
                    {
                        case "dup":
                            {
                                int duplicate = numbers.Peek();
                                numbers.Push(duplicate);
                            }
                            break;
                        case "pop":
                            {
                                numbers.Pop();
                            }
                            break;
                        case "+":
                            {
                                int topFirst = numbers.Pop();
                                int topSecond = numbers.Pop();

                                numbers.Push(topFirst + topSecond);
                            }
                            break;
                        case "-":
                            {
                                int topFirst = numbers.Pop();
                                int topSecond = numbers.Pop();

                                numbers.Push(topFirst - topSecond);
                            }
                            break;
                        default:
                            {
                                numbers.Push(Convert.ToInt32(commands[i]));
                            }
                            break;
                    }
                }

                return numbers.Pop();
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
