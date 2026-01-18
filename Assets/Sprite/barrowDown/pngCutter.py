from PIL import Image
import os

# Frame-ek helye
frames_folder = "D:/Unity/2025/tinyElf/Assets/Sprite/barrowDown"
output_file = "D:/Unity/2025/tinyElf/Assets/Sprite/barrowDown/spritesheet.png"

# Frame-ek betöltése és méret ellenőrzése
frames = []
for filename in sorted(os.listdir(frames_folder)):
    if filename.endswith(".png"):
        frame = Image.open(os.path.join(frames_folder, filename))
        frames.append(frame)

# Feltételezzük, hogy minden frame ugyanakkora
frame_width, frame_height = frames[0].size
sheet_width = frame_width * len(frames)
sheet_height = frame_height

# Új üres kép létrehozása
spritesheet = Image.new("RGBA", (sheet_width, sheet_height))

# Frame-ek egymás mellé illesztése
for i, frame in enumerate(frames):
    spritesheet.paste(frame, (i * frame_width, 0))

# Mentés
spritesheet.save(output_file)
print(f"Spritesheet elkészült: {output_file}")