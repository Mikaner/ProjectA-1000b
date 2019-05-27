filePath = input()

txtFile = open(filePath,encoding="utf-8")
data = txtFile.read()
txtFile.close()

out = data.replace("\n@br\n\n\n\n@br\n","\n@br\n")


with open("./Output.txt","w",encoding="utf-8") as f:
    f.write(out)