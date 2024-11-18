#ifndef COMMANDHANDLER_H
#define COMMANDHANDLER_H
class CommandHandler {
  private:
    float inputValue;
    Stream& _inputStream;
    float GetFloatInput(Stream& _inputStream);
    bool IsFloat(String input);
	public:
    CommandHandler(Stream& inputStream);
		float GetInput();
 };

#endif // !COMMANDHANDLER_H
