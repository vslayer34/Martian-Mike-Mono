extends ParallaxBackground

@onready var sprite_node: Sprite2D = $ParallaxLayer/Sprite2D

@export_category("Properties")
@export var bg_texture: CompressedTexture2D = preload("res://Assets/Textures/bg/Blue.png")
@export var scroll_speed: float = 15

const TEXTURE_SIZE: float = 64

func  _process(delta):
	if (sprite_node.region_rect.position >= Vector2(TEXTURE_SIZE, TEXTURE_SIZE)):
		sprite_node.region_rect.position = Vector2.ZERO
	
	sprite_node.region_rect.position += Vector2(scroll_speed, scroll_speed) * delta
