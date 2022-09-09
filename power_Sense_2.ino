#include <Esplora.h>
int button = 0;


void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
}

void loop() {
  // put your man code here, to run repeatedly:
int JoyX = Esplora.readJoystickX();
int JoyY = Esplora.readJoystickY();

int xAxis = Esplora.readAccelerometer(X_AXIS);    // read the Y axis
int yAxis = Esplora.readAccelerometer(Y_AXIS);    // read the Y axis

int button1 = Esplora.readButton(SWITCH_LEFT);
int button2 = Esplora.readButton(SWITCH_DOWN);
int button3 = Esplora.readButton(SWITCH_RIGHT);
int button4 = Esplora.readButton(SWITCH_UP);



Serial.print(yAxis);
Serial.print(",");
Serial.print( JoyX);
Serial.print(",");
Serial.print(xAxis);
Serial.print(",");
Serial.println(button);

if(button1 == LOW)
  {
    Esplora.writeRGB(0, 187, 45);
    button = 1;
  }
  
if(button2 == LOW)
  {
    Esplora.writeRGB(255, 255, 0);
    button = 2;
  }
  
if(button3 == LOW)
  {
    Esplora.writeRGB(255, 0, 0);
    button = 3;
  }
  
if(button4 == LOW)
  {
    Esplora.writeRGB(0, 0, 255);
    button = 4;
  }

}
