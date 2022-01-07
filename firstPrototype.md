# ~1/6 1차 study

## Scene 1
### Authentication.cs
##### 기본 설정값
ID := "User"
PW := "1234"

입력 ID와 PW가 기본 설정값과 같으면 다음씬으로 이동. 

else 다시 같은 씬으로 복귀. (재 로그인)
###### 첨언
> 데이터베이스 도입이 유리해보임.
###### 설명
> Demo Chat에서처럼 UserId를 입력받아서 정보 이용하려고 명목상 만들었는데, 씬이 넘어가면 입력 데이터가 사라지는 탓에
저장된 ID인 User를 입력할 때만 실행되도록 만듦.
###### 대안
> DontDestroyOnLoad 사용.

> 씬 변환 대신 SetActive(T/F)로 같은 씬에서 화면전환해서 입력데이터 사용.


## Scene 2
### ChatScript.cs
##### 연결
AppId X > 
서버 미연결 :=> OnDisconnected( ) 실행

AppId O >
서버 연결 :=> OnConnected( ) 실행 후 기본으로 설정한 채널(Channel 001) 구독 후 public 메세지 입력

##### InputField inputField
메시지 입력 후 Enter

##### Text outputText
{senderName} : {message} 형태로 AddLine

##### 추가
> private message 기능

> stroage (local 저장 값 확인용) + etc(친구 리스트, 채널 리스트, 구독 리스트,,,)..

> 도움말(help)

> 유저 상태 표시
##### 설명
> Chat 기본 기능 수행. AddLine으로 메세지 output관리
##### 대안
> client.Add(...) 메서드 사용.

> client의 여타 메서드를 사용하여 시의적절하게 데이터 관리.


##### 기타사항
> 디버깅 (sender[], message[] 등 local 저장 값 확인)

> 설계(기능, UI, etc..)

## Reference
https://photonkr.tistory.com/9?category=1030313

https://timeboxstory.tistory.com/84

https://foxtrotin.tistory.com/119
> +db

https://foreverhappiness.tistory.com/94

https://foreverhappiness.tistory.com/100?category=882368
