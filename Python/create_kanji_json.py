from urllib import response
import requests
from bs4 import BeautifulSoup
import re
import json


# URLからHTMLテキストデータを取得
url = 'https://www.benricho.org/kanji/kyoikukanji/2nen.html'
response = requests.get(url)
response.encoding = response.apparent_encoding
html_text = response.text

# bs4を用いて、テーブル内のtd要素一覧を取得
soup = BeautifulSoup(html_text, 'html.parser')
table = soup.find('table')
td_list = table.find_all('td')

# 保存用のjson
json_dict = {'kanjiInfos':[]}

for tl in td_list:
    # 漢字の取得
    kanji = re.match(r'<td class="textpopup".*?>(.+?)<div class="yomi">', str(tl), re.MULTILINE | re.DOTALL).group(1)
    kanji = kanji.replace('\n', '')
    kanji = kanji.replace(' ', '')

    # 漢字の読み方、画数などの情報を取得
    kanji_info = str(tl.find('div', class_='yomi'))
    kanji_info = re.match(r'<div class="yomi">(.+?)</div>', kanji_info, re.MULTILINE | re.DOTALL).group(1)

    # 画数を取得する
    kakusu = re.match(r'.+?画数：(\d+)画.+', kanji_info, re.MULTILINE | re.DOTALL).group(1)

    # 読みを取得する
    yomi = re.match(r'(.+?)画数.+', kanji_info, re.MULTILINE | re.DOTALL).group(1)
    yomi = yomi.replace('\n', '')  # 改行除去
    yomi = yomi.replace(' ', '')  # 空白除去
    yomi = yomi.split('<br/>')  # 改行区切りで分割
    yomi_list = [''.join(y.split()) for y in yomi if y != '']  # 空文字を配列から除去（y.split()で不要な空白を除去している）

    # 音読み、訓読みごとに配列に追加
    onyomi_list, kunyomi_list = [], []
    re_katakana = re.compile(r'[\u30A1-\u30F4]+')
    for yl in yomi_list:
        if re_katakana.fullmatch(yl):
            onyomi_list.append(yl)
        else:
            kunyomi_list.append(yl)
    
    # jsonに追加
    json_dict['kanjiInfos'].append(
        {
            'kanji': kanji
            , 'onyomi': onyomi_list
            , 'kunyomi': kunyomi_list
            , 'kakusu': kakusu
        }
    )

# jsonデータのファイル出力
with open('../Assets/Data/KanjiInfos.json', 'w') as file:
    json.dump(json_dict, file, ensure_ascii=False, indent=4)