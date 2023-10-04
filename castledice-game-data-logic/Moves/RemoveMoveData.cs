﻿using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class RemoveMoveData : MoveData
{
    public override MoveType MoveType => MoveType.Remove;
}