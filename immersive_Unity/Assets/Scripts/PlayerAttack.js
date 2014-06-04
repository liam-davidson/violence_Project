var target : GameObject;
var attackTimer : float;
var coolDown : float;

function Start()
{
	attackTimer = 0.0;
	coolDown = 1.0;
}

function Update()
{
	if(attackTimer > 0)
		attackTimer -= Time.deltaTime;
	if(attackTimer < 0)
		attackTimer = 0;
		
	if(Input.GetMouseButtonUp(0))
	{
		if(attackTimer == 0)
		{
			Attack();
			attackTimer = coolDown;
		}
	}
	if(Input.GetMouseButtonUp(1))
	{
		if(attackTimer == 0)
		{
			Attack();
			attackTimer = coolDown;
		}
	}
}

function Attack()
{
	var distance = Vector3.Distance(target.transform.position, transform.position);
	var dir : Vector3 = (target.transform.position - transform.position).normalized;
	var direction = Vector3.Dot(dir, transform.forward);
	
	Debug.Log(direction);
}