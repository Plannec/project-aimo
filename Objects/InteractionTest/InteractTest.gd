extends Area2D

onready var SPRITE = $"./Sprite"

func _ready():
	pass

func _on_InteractTest_body_entered(body):
	SPRITE.set_texture(load("res://Objects/InteractionTest/InteractionTestSpriteOut.png"))

func _on_InteractTest_body_exited(body):
	SPRITE.set_texture(load("res://Objects/InteractionTest/InteractionTestSprite.png"))
