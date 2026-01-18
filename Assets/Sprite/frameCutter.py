from PIL import Image
import os
import math
import re

# Frame-ek helye
frames_folder = "D:/Unity/2025/tinyElf/Assets/Sprite/UIElements/star"  # ide tedd a PNG-ket
output_file = "D:/Unity/2025/tinyElf/Assets/Sprite/UIElements/star/spritesheet.png"
frames_per_row = 10
padding = 10

# --- SEGÉDFÜGGVÉNY A NUMERIKUS + LEXIKÁLIS RENDEZÉSHEZ ---
def alphanumeric_sort_key(filename):
    """
    A fájlnevet darabolja szöveges és numerikus részekre,
    így pl. sprite_2.png < sprite_10.png lesz.
    """
    parts = re.split('([0-9]+)', filename)
    key = []
    for part in parts:
        if part.isdigit():
            key.append(int(part))
        else:
            key.append(part.lower())
    return key

# --- FRAME-EK BETÖLTÉSE ÉS RENDEZÉSE ---
frames = []
for filename in sorted(os.listdir(frames_folder), key=alphanumeric_sort_key):
    if filename.lower().endswith(".png"):
        frame = Image.open(os.path.join(frames_folder, filename)).convert("RGBA")
        frames.append(frame)

if not frames:
    raise ValueError("Nincsenek PNG fájlok a megadott mappában.")

# --- MÉRETEK SZÁMÍTÁSA ---
frame_width, frame_height = frames[0].size
rows = math.ceil(len(frames) / frames_per_row)
sheet_width = frame_width * min(frames_per_row, len(frames)) + padding * (min(frames_per_row, len(frames)) - 1)
sheet_height = frame_height * rows + padding * (rows - 1)

# --- ÚJ ÜRES SPRITESHEET LÉTREHOZÁSA ---
spritesheet = Image.new("RGBA", (sheet_width, sheet_height), (0, 0, 0, 0))

# --- FRAME-EK ELHELYEZÉSE A SPRITESHEET-EN ---
for index, frame in enumerate(frames):
    row = index // frames_per_row
    col = index % frames_per_row
    x = col * (frame_width + padding)
    y = row * (frame_height + padding)
    spritesheet.paste(frame, (x, y))

# --- MENTÉS ---
spritesheet.save(output_file)
print(f"Spritesheet elkészült: {output_file}")
print(f"Mérete: {sheet_width}x{sheet_height}, sorok: {rows}, oszlopok max: {frames_per_row}, padding: {padding}px")