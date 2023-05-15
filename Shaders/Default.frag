#version 330 core

in vec2 texCoord;
in float brightness;
out vec4 FragColor;

uniform sampler2D tex;

void main() {
	vec4 texColor = texture(tex, texCoord);
	FragColor = vec4(texColor.rgb * brightness, texColor.a);
}