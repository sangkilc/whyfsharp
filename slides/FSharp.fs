namespace MyPPTX

open MyPPTX.PPTHelper
open Syncfusion.Presentation

type FSharp () =

  let title pptx =
    addSlide pptx SlideLayoutType.Title
    |> putTitle "F#"
    |> endSlide pptx

  let dotNet pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "닷넷 (.NET)"
    |> appendParagraphToContent "1990년대에 마이크로소프트가 개발 시작"
    |> appendParagraphToContent
      "다양한 기기에서 다양한 언어로 쓰인 프로그램을 안전하게 구동하자"
    |> appendParagraphToContent "닷넷에서 최초로 구현된 함수형 언어 = F#"
    |> addTextAnimation
    |> endSlide pptx

  let fsharpBeginning pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "F#의 시작"
    |> appendParagraphToContent
      "2000년대 들어 MS는 함수형 패러다임의 중요성을 인식"
    |> appendParagraphToContent "닷넷에서의 함수형 언어를 만들자!"
    |> appendParagraphToContent
      "함수형 언어 개발자들 대거 영입 (예: Lucan Cardelli, Simon Peyton Jones)"
    |> appendParagraphToContent "최초의 시도 = Haskell.NET"
    |> addTextAnimation
    |> endSlide pptx

  let failureOfHaskell pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "Haskell.NET의 실패"
    |> appendParagraphToContent
      "닷넷과 Haskell언어는 근본적으로 궁합이 맞지 않는다"
    |> appendParagraphToContent "아예 새롭게 만들자!"
    |> addTextAnimation
    |> endSlide pptx

  let newLanguage pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "새로운 언어 (F#) 의 탄생"
    |> appendParagraphToContent "OCaml의 신택스를 기본으로 하되"
    |> appendParagraphToContent "다양한 프로그래밍 언어 철학을 대거 수용"
    |> appendParagraphToContent "이제는 신택스도 OCaml과 점점 멀어지고 있음"
    |> addTextAnimation
    |> endSlide pptx

  let whyDifferent pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "F# vs. 기존의 함수형 언어"
    |> appendParagraphToContent "효율성: 속도가 빠름"
    |> appendParagraphToContent "실용성: 극강의 라이브러리 보유 (.NET)"
    |> appendParagraphToContent "사용성: 다양한 개발, 디버깅 도구"
    |> appendParagraphToContent "범용성: 어디에서나 동작"
    |> appendParagraphToContent "미래성: 공개소스 커뮤니티에서 건강하게 진화중"
    |> addTextAnimation
    |> endSlide pptx

  let differentPrinciple pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "F#의 기본 철학"
    |> appendParagraphToContent "함수형 언어가 아님"
    |> appendParagraphToContent "함수우선 (Functional-First) 언어"
    |> appendParagraphToContent "고지식하지 않겠다. 버릴 건 버리겠다"
    |> appendParagraphToContent "최대한 간결하게, 그리고 이해하기 쉽게"
    |> addTextAnimation
    |> endSlide pptx

  let conciseness pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "F#의 간결성"
    |> putCenterImage "../images/csharp-fsharp-compare.jpg" false
    |> putFootnote "출처: https://1drv.ms/p/s!Ag2Nv7CJvPcc4TUgRf01AszRF0h6"
    |> endSlide pptx

  let theImpact pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "F#의 강력한 실용성"
    |> appendParagraphToContent
      "본 발표자료는 .NET라이브러리를 활용하여 F#으로 짜여짐"
    |> appendParagraphToContent "단 630줄의 F# 코드로 짜여짐"
    |> appendParagraphToContent "소스: https://github.com/sangkilc/whyfsharp"
    |> appendParagraphToContent "발표자료를 F#으로 쓰면 정리가 잘 됨!"
    |> addTextAnimation
    |> endSlide pptx

  let finalComment pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "F#의 세계로 초대합니다"
    |> removeDefaultContent
    |> putCenterText "실용적이면서 범용적이고 쓰기편하고 우아하고 빠른 언어"
    |> endSlide pptx

  static member Add pptx =
    let grp = FSharp () :> SlideGroup
    grp.Add pptx

  interface SlideGroup with
    member __.Add pptx =
      pptx
      |> title
      |> dotNet
      |> fsharpBeginning
      |> failureOfHaskell
      |> newLanguage
      |> whyDifferent
      |> differentPrinciple
      |> conciseness
      |> theImpact
      |> finalComment

