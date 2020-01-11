namespace MyPPTX

open MyPPTX.PPTHelper
open Syncfusion.Presentation

type Intro () =

  let title pptx =
    addSlide pptx SlideLayoutType.Title
    |> putTitle "Why F#?"
    |> putAuthor "차상길"
    |> endSlide pptx

  let bio pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "차상길 (Sang Kil Cha)"
    |> appendParagraphToContent "F#을 산소처럼 사용하는 사람"
    |> appendParagraphToContent "F# 재단 (F# Foundations) 공식 연사"
    |> addTextAnimation
    |> endSlide pptx

  let myYoungAge pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "어린시절 이야기"
    |> putMaxImage "../images/oldcomputer.jpg" true
    |> putMaxImage "../images/oldgame.jpg" true
    |> putMaxImage "../images/diskette.jpg" true
    |> putMaxImage "../images/ncd.jpg" true
    |> endSlide pptx

  let myDream pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "나의 꿈"
    |> putCenterText "컴퓨터 가게 사장님이 되어야지!"
    |> endSlide pptx

  let firstStep pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "꿈을 향한 첫 걸음: GW-BASIC"
    |> putMaxImage "../images/gwbasic.jpg" false
    |> endSlide pptx

  let moreStudy pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "공부, 공부 ..."
    |> putImage "../images/book-c.jpg" 90.0 143.0 200.0 300.0 true
    |> putImage "../images/book-c++.jpg" 350.0 143.0 200.0 300.0 true
    |> putImage "../images/book-java.jpg" 600.0 143.0 200.0 300.0 true
    |> endSlide pptx

  let myUndergrad pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "컴퓨터 전문가의 길로"
    |> appendParagraphToContent "학부 논리회로 수업에서의 충격"
    |> appendParagraphToContent "공부에 대한 갈증!"
    |> addTextAnimation
    |> endSlide pptx

  let studyAbroad pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "유학길"
    |> appendParagraphToContent "컴퓨터 분야 최고 대학인 CMU로 진학"
    |> appendParagraphToContent "지도교수님과의 첫 만남"
    |> addTextAnimation
    |> endSlide pptx

  let myAdvisor pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "지도교수님의 첫 질문"
    |> putCenterText "너 ML 할 줄 아니?"
    |> endSlide pptx

  let startOCaml pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "엉겁결에 시작한 OCaml"
    |> appendParagraphToContent "자신감 만큼은 세계 최고!"
    |> appendParagraphToContent "새로운 언어, 뭐 별거 있겠어?"
    |> addTextAnimation
    |> endSlide pptx

  static member Add pptx =
    let grp = Intro () :> SlideGroup
    grp.Add pptx

  interface SlideGroup with
    member __.Add pptx =
      pptx
      |> title
      |> bio
      |> myYoungAge
      |> myDream
      |> firstStep
      |> moreStudy
      |> myUndergrad
      |> studyAbroad
      |> myAdvisor
      |> startOCaml

