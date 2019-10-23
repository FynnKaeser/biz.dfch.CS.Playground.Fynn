/**
 * Copyright 2019 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Playground.Fynn._20191021
{
    public class PlayerManager
    {
        private IList<Player> players = new List<Player>();

        public IList<Player> GetPlayers()
        {
            return players;
        }

        public Player CreatePlayer(string firstName, string lastName, int goalsScored)
        {
            var player = new Player(firstName, lastName, goalsScored);
            players.Add(player);

            return player;
        }

        public Player GetFirstPlayer(string firstName)
        {
            var player = (from p in players
                          where p.FirstName == firstName
                          select p).First();

            return player;
        }

        public Player GetSinglePlayer(string firstName)
        {
            var player = (from p in GetPlayers()
                          where p.FirstName == firstName
                          select p).Single();

            return player;
        }

        public Player GetFirstOrDefaultPlayer(string firstName)
        {
            var player = (from p in players
                          where p.FirstName == firstName
                          select p).FirstOrDefault();

            return player;
        }

        public Player GetSingleOrDefaultPlayer(string firstName)
        {
            var player = (from p in GetPlayers()
                          where p.FirstName == firstName
                          select p).SingleOrDefault();

            return player;
        }

        public Player GetNthFirstPlayerScoredLessThanTenGoals(int skipCount)
        {
            var player = (from p in GetPlayers()
                          where p.GoalsScored < 10
                          orderby p.GoalsScored descending
                          select p).Skip(skipCount - 1).First();

            return player;
        }
    }

    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GoalsScored { get; set; }

        public Player(string firstName, string lastName, int goalsScored)
        {
            FirstName = firstName;
            LastName = lastName;
            GoalsScored = goalsScored;
        }
    }
}
