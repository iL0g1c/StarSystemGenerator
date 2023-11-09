import csv
import pandas as pd
import re

def spreadsheetConverter():
    # Loads excel sheet
    df = pd.read_excel('starStats.xlsx')
    data = df.values

    # Filters out unneeded characters 
    text_filter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ* "
    parsed_data = []
    for item in data:
        cleaned_string = re.sub(r'[a-zA-Z* ]', '', item[0])
        cleaned_string = cleaned_string.replace(",", ".")
        parsed_data.append(cleaned_string)

    # Combines double lines into single entries
    merged_data = []
    i = 0
    while i < len(parsed_data) - 1:
        merged_data.append(parsed_data[i] + "/" + parsed_data[i+1])
        char_count = merged_data[-1].count("-")
        if char_count > 0:
            modified_string = merged_data.pop()
            modified_string = modified_string.replace("-", "")
            merged_data.append(modified_string)
            for _ in range(char_count):
                merged_data.append("")
        i += 2

    # Converts 1D list to 2D
    max_columns = 10
    organized_data = [merged_data[i:i + max_columns] for i in range(0, len(merged_data), max_columns)]

    # Saves 2D list to CSV
    with open("starNumberType.csv", "w") as file:
        writer = csv.writer(file)
        for item in organized_data:
            writer.writerow(item)
    file.close()

if __name__ in "__main__":
    spreadsheetConverter()