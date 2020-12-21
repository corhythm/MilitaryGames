# MilitaryGames
군대에서 만든 미니 게임 (테트리스, 지렁이 키우기): https://youtu.be/OSXEX-z0xTs
https://youtu.be/OSXEX-z0xTs
당직 설 때, 할 거 없어서 당직 인트라넷 PC로 만듬(C#)
~~C# WPF로 만들고 싶었지만, 내가 근무하던 당시엔 Win 7이었고, GUI 사용하려면 WinForm만 사용가능 했다는...ㅜㅜ~~


## 최초 실행 시, 로그인 페이지
<img src="https://user-images.githubusercontent.com/43941383/102473706-1ddc0880-409b-11eb-9359-7c7e062c10d1.PNG" width="30%" height="60%">


## 로그인에 성공하면 게임을 선택할 할 수 있는 SeletForm(테트리스, 지렁이 키우기, 랭킹보기 (NotYet은 아직 개발 중)
<img src="https://user-images.githubusercontent.com/43941383/102473788-38ae7d00-409b-11eb-9e49-9e0547eadaba.png" width="30%" height="60%">


## 테트리스 플레이 화면
<img src="https://user-images.githubusercontent.com/43941383/102473925-5da2f000-409b-11eb-8f1b-91e4a97a9919.png" width="30%" height="60%">


## 키보드의 P 자판을 누르면 스레드가 블록이 떨어지는 스레드가 일시정지 되며, 다시 P를 누르면 시작한다
<img src="https://user-images.githubusercontent.com/43941383/102474009-76130a80-409b-11eb-8bc5-8acf699b2120.png" width="30%" height="60%">


## 블록 저장 기능, H 버튼을 누르면 현재 떨어지고 있는 블록이 좌측 상단에 저장되고 저장된 블록은 H 버튼을 다시 누르면 사용할 수 있다. 블록 저장 기능은 계속 사용하면 게임의 밸런스를 해칠 수 있을 거 같아, 재사용까지 10초의 제한을 두었다
<img src="https://user-images.githubusercontent.com/43941383/102474088-8f1bbb80-409b-11eb-9ea2-ea8b4cfac1bd.png" width="30%" height="60%">


## 게임 끝났을 때, 기록이 순위에 들면 기록 저장 의사를 묻는다
<img src="https://user-images.githubusercontent.com/43941383/102474183-b1153e00-409b-11eb-82cf-9b13e1739896.png" width="30%" height="60%">


## 기록 저장 시 필요한, ID, Email 입력
<img src="https://user-images.githubusercontent.com/43941383/102474364-e3bf3680-409b-11eb-8f71-27c24cd7352d.png" width="30%" height="50%">


## 저장된 기록 보여주기: 군대에라 DB가 없어서 메모장 파일을 DB처럼 이용했다
<img src="https://user-images.githubusercontent.com/43941383/102474464-06514f80-409c-11eb-94d7-bdd44f6f36de.png" width="70%" height="100%">


## 랭킹 입력 완료 후, 다시 플레이 할 건지 묻고, 아니오를 클릭하면 SelectForm으로 되돌아간다
<img src="https://user-images.githubusercontent.com/43941383/102476362-5b8e6080-409e-11eb-918e-bad9902228d9.png" width="50%" height="50%">


## 지렁이 키우기: 파란색 블록를 먹으면 지렁이의 몸집이 커지고, 빨간색 블록을 먹거나 벽에 부딪히면 게임이 끝난다. 색깔이 알록달록한 블록은 점프게이트로서 점프게이트에 들어가면 랜덤으로 아무 점프게이트로 나온다. 어느 점프게이트로 나올지는 Random.Next(점프게이트 개수)를 사용했다
<img src="https://user-images.githubusercontent.com/43941383/102476638-ab6d2780-409e-11eb-8961-2c93b249ef87.png" width="50%" height="50%">
