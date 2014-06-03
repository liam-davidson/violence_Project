function Update () 
{
	PlayAttackAnim();
}

function PlayAttackAnim()
{
	if(Input.GetMouseButtonUp(0))
	{
		animation.Play("Slash_01");
	}
	else if(Input.GetMouseButtonUp(1))
	{
		animation.Play("Slash_02");
	}
	else if(!animation.IsPlaying("Slash_01") && !animation.IsPlaying("Slash_02"))
	{
		animation.Play("Idle");
	}
}