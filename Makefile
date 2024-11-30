clean:
	rm -f inputs.txt
	rm -rf bin
	rm -rf obj

paste-inputs:
	wl-paste > inputs.txt

run:
	dotnet run