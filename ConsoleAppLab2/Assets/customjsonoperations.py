# -*- coding: utf-8 -*-
"""
custom json operations
"""
import json
print("hey, it's me - Python!")
f = open('data2.json',)
data = json.load(f)

# przykładowe statystyki
example_stat = 0
for x in data['buses']:
	if x['udogodnienia']['klimatyzacja'] == 'nie' and x['danePodstawowe']['rok_produkcji'] is not None and int(x['danePodstawowe']['rok_produkcji']) > 2010:
		example_stat += 1

print('nowe busy bez klimatyzacji: ' + ' ' + str(example_stat))

# TODO – selekcja i transformacja danych
"""
lst = []
lst.append({"nr_inwentarzowy":1, "rodzaj_pojazdu":2, "typ_pojazdu":3, "rok produkcji":4, "liczba_miejsc_stojacych":5, "liczba_miejsc_siedzacych":6, "mocowanie_rowerow":7})
jsontemp = {"buses":lst}
with open('data3.json', 'w',encoding='utf-8') as f:
	json.dump(jsontemp, f)
"""