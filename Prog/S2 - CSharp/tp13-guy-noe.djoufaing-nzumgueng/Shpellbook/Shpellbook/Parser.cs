﻿using System;
using System.IO;

namespace Shpellbook
{
    /// <summary>
    ///     Shall create sensible commands
    /// </summary>
    public class Parser
    {
        /// <summary>
        ///     The input stream
        /// </summary>
        private TextReader _input;

        public Parser(TextReader input)
        {
            _input = input;
        }

        /// <summary>
        ///     Must return a fully formed command, you can find examples
        ///     of a command in the subject or null if the input is empty or bad
        /// </summary>
        /// <returns>A Command object or null</returns>
        /// <example>
        ///     Input:
        ///     shpellbook$ echo my name is toto
        ///     Shall return:
        ///     Command{args{"echo", "my", "name", "is", "toto"}}
        /// </example>
        public Command ParseInput()
        {
            string[] res = _input.ReadLine().Split(' ');
            if (res.Length == 0)
                throw new ArgumentException("Empty command");

            return (new Command(res));
        }
    }
}