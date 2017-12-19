using System.Collections.Generic;

namespace TuringMachine
{
    public static class TransitionTableGenerator
    {
        public static IEnumerable<Transition> Reverse() => new[]
        {
            new Transition(0, '0', '0', HeadDirection.Right, 0),
            new Transition(0, '1', '1', HeadDirection.Right, 0),
            new Transition(0, Head.Blank, Head.Blank, HeadDirection.Left, 1),

            new Transition(1, 'x', 'x', HeadDirection.Left, 1),
            new Transition(1, '0', 'x', HeadDirection.Right, 2),
            new Transition(1, '1', 'x', HeadDirection.Right, 3),
            new Transition(1, Head.Blank, Head.Blank, HeadDirection.Right, 5),

            new Transition(2, '0', '0', HeadDirection.Right, 2),
            new Transition(2, '1', '1', HeadDirection.Right, 2),
            new Transition(2, 'x', 'x', HeadDirection.Right, 2),
            new Transition(2, Head.Blank, '0', HeadDirection.Left, 4),

            new Transition(3, '0', '0', HeadDirection.Right, 3),
            new Transition(3, '1', '1', HeadDirection.Right, 3),
            new Transition(3, 'x', 'x', HeadDirection.Right, 3),
            new Transition(3, Head.Blank, '1', HeadDirection.Left, 4),

            new Transition(4, 'x', 'x', HeadDirection.Left, 1),
            new Transition(4, '0', '0', HeadDirection.Left, 4),
            new Transition(4, '1', '1', HeadDirection.Left, 4),
                
            new Transition(5, 'x', Head.Blank, HeadDirection.Right, 5),
            new Transition(5, '0', '0', HeadDirection.NoMove, 6),
            new Transition(5, '1', '1', HeadDirection.NoMove, 6),
        };
    }
}