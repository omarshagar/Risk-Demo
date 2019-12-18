using Godot;
using System;


public class number_map : TileMap
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(float delta)
  {
             //_on_Area2D_mouse_entered();    
  }


	private void _on_Area2D_mouse_entered()
    {
		
    }
	private void _on_Area2D_input_event(object viewport, object @event, int shape_idx)
	{
        if(Input.IsActionJustPressed("LM"))
        {
            GD.Print(GetChild(shape_idx));
        }
    }


}
