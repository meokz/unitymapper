# 動作環境
- Windows10
- Leap Motion SDK Windows 3.1.3

# 開発環境
- Unity 5.5.0f3 Personal

# 導入ライブラリ＆アセット
- StandardAssets https://www.assetstore.unity3d.com/jp/#!/content/32351 (不要なものは除去済)
- Unityちゃん http://unity-chan.com/contents/guideline/
- LeapMotion CoreAsset Orion 4.1.5.unitypackage

# Hierarchyの説明
- ObjectWorld
	- Unity上の実世界。UIなどを表示するMainDisplay、Light、それぞれのプロジェクタ(を模したカメラ)が設置されている。ProjectedObjectに投影したい物体を追加してく。
- VirtualWorld
	- キャリブレーション用の仮想世界。ObjectWoldのカメラから持ってきた映像を平面に描画し、その平面を変形させ、それをカメラで映すことで映像をキャリブレーションする。
- Manager
	- スクリプトを貼り付けていくオブジェクト。全体を操作するスクリプトはここに貼り付けておくと分散しないため、ソースコードを追いやすい。
- Canvas
	- UIを作る
- EventSystem
	- UIのイベント(クリックとか)を発生させてる。無視してて良い。

# フォルダ構成の説明
- Editor
	- Unity Editorの拡張．普段触ることはない．
- LeapMotion
	- LeapMotionのライブラリ．
- Plugin
	- DLLファイルの配置場所．
- Standard Assets
	- スタンダードアセット．不要なものは除いている．ParticleSystemやPhysicsMaterialが使えるかもしれない．
- UnityChan
	- ユニティちゃんのモデルやモーションデータ．
- UnityMapper
	- 大峠が追加したソースコードやパーティクルなどのPrefabs．