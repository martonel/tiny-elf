from PIL import Image
import os
import math
import re

# Frame-ek helye
frames_folder = "D:/Unity/2025/tinyElf/Assets/Sprite/nothing"  # ide tedd a PNG-ket
output_file = "D:/Unity/2025/tinyElf/Assets/Sprite/nothing/spritesheet.png"
frames_per_row = 10
padding = 10

# Segédfüggvény a numerikus rendezéshez
def numerical_sort(value):
    numbers = re.findall(r'\d+', value)
    return int(numbers[0]) if numbers else 0

# Frame-ek betöltése és rendezése név szerint
frames = []
for filename in sorted(os.listdir(frames_folder), key=numerical_sort):
    if filename.lower().endswith(".png"):
        frame = Image.open(os.path.join(frames_folder, filename)).convert("RGBA")
        frames.append(frame)

if not frames:
    raise ValueError("Nincsenek PNG fájlok a megadott mappában.")

# Feltételezzük, hogy minden frame ugyanakkora
frame_width, frame_height = frames[0].size
rows = math.ceil(len(frames) / frames_per_row)

# Új üres kép létrehozása padding-gel
sheet_width = frame_width * min(frames_per_row, len(frames)) + padding * (min(frames_per_row, len(frames)) - 1)
sheet_height = frame_height * rows + padding * (rows - 1)
spritesheet = Image.new("RGBA", (sheet_width, sheet_height), (0,0,0,0))

# Frame-ek egymás mellé/sorba illesztése
for index, frame in enumerate(frames):
    row = index // frames_per_row
    col = index % frames_per_row
    x = col * (frame_width + padding)
    y = row * (frame_height + padding)
    spritesheet.paste(frame, (x, y))

# Mentés
spritesheet.save(output_file)
print(f"Spritesheet elkészült: {output_file}")
print(f"Mérete: {sheet_width}x{sheet_height}, sorok: {rows}, oszlopok max: {frames_per_row}, padding: {padding}px")