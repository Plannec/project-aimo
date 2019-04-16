extends KinematicBody2D

# Constains for movement
const SPEED = 60
const RUN_MULTIPLIER = 2
const GRAVITY = 10
const JUMP_POWER = -180
const FLOOR = Vector2(0, -1)


var velocity = Vector2()
var look_direction = Vector2(1, 0)

# Get camara
onready var camera = $Pivot/CameraOffset/Camera2D

func _physics_process(delta):
	var RIGHT = Input.is_action_pressed("ui_right")
	var LEFT = Input.is_action_pressed("ui_left")
	var JUMP = Input.is_action_pressed("ui_up")
	var SNEAK = Input.is_action_pressed("ui_down")
	var RUN = Input.is_action_pressed("ui_shift")

	# Right (1, 0)
	if RIGHT:
		# Zoom out on running
		if RUN:
			camera.set_zoom(Vector2(1.1, 1.1))
		else:
			camera.set_zoom(Vector2(1, 1))
			
		if RUN:
			velocity.x = SPEED*RUN_MULTIPLIER
		else:
			velocity.x = SPEED
		look_direction = Vector2(1, 0)
		$AnimatedSprite.play("run")
		$AnimatedSprite.set_flip_h(false);
	# Left (-1, 0)
	elif LEFT:
		# Zoom out on running
		if RUN:
			camera.set_zoom(Vector2(1.1, 1.1))
		else:
			camera.set_zoom(Vector2(1, 1))
			
		if RUN:
			velocity.x = -SPEED*RUN_MULTIPLIER
		else:
			velocity.x = -SPEED
		$AnimatedSprite.play("run")
		$AnimatedSprite.set_flip_h(true);
		look_direction = Vector2(-1, 0)
	else:
		velocity.x = 0
		camera.set_zoom(Vector2(1, 1))
		$AnimatedSprite.play("idle")
		
	# Jump
	if JUMP and is_on_floor():
		velocity.y = JUMP_POWER
		$AnimatedSprite.play("jump")
		
	velocity.y += GRAVITY
	
	velocity = move_and_slide(velocity, FLOOR)