#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aUV; // tex coords
layout (location = 2) in float aBrightness;

out vec2 texCoord;
out float brightness;

uniform mat4 scalingMatrix;
uniform mat4 model;
uniform mat4 view;
uniform mat4 proj;

void main() {
	gl_Position = scalingMatrix * vec4(aPosition, 1.0) * model * view * proj;
	texCoord = aUV;
	brightness = aBrightness;
}