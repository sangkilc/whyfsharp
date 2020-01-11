namespace MyPPTX

open MyPPTX.PPTHelper
open Syncfusion.Presentation

type BigWave () =

  let title pptx =
    addSlide pptx SlideLayoutType.Title
    |> putTitle "함수형 패러다임의 물결"
    |> endSlide pptx

  let bigWave pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "함수형 언어는 거스를 수 없는 \"대세\""
    |> appendParagraphToContent "Python? Rust?"
    |> appendParagraphToContent "심지어 C++도!?"
    |> appendParagraphToContent
      "(C++11 부터) 함수의 partial application, lambda expression 등 지원"
    |> appendParagraphToContent
      "모든 언어는 진화중이며 그 중심에는 함수형 패러다임이 있음!"
    |> addTextAnimation
    |> endSlide pptx

  let developerSurvey pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "스택오버플로우 개발자 설문조사"
    |> putMaxImage "../images/stackoverflow-survey.jpg" false
    |> endSlide pptx

  let resultOne pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "설문결과 (1)"
    |> removeDefaultContent
    |> putCenterImage "../images/stackoverflow-toppaying-2019.jpg" false
    |> putCenterText "고위 프로그래머일수록 함수형 패러다임을 좋아한다"
    |> addSequentialShapeAnimation
    |> endSlide pptx

  let janeStreet pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "Jane Street의 사례"
    |> appendParagraphToContent
      "금융 투자 회사: 양적 거래 (Quantitative Trading) 전략을 사용"
    |> appendParagraphToContent "매일 15조원 규모의 자금을 거래"
    |> appendParagraphToContent "2019년 한 해에만 1429억원의 순이익을 거둠"
    |> appendParagraphToContent "경제 전문가 (X), 기술 개발자 (O)"
    |> appendParagraphToContent "OCaml로 모든 것을 개발함!"
    |> appendParagraphToContent "개발자들의 평균 연봉 = 7억 4천만원"
    |> putFootnote "출처: https://news.efinancialcareers.com/uk-en/3002331/jane-street-jobs-and-salaries"
    |> addTextAnimation
    |> endSlide pptx

  let piLab pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "PiLab 사례"
    |> appendParagraphToContent "F#중심의 기술개발"
    |> appendParagraphToContent "F# Meetup의 스폰서!"
    |> addTextAnimation
    |> endSlide pptx

  let resultTwo pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "설문결과 (2)"
    |> removeDefaultContent
    |> putCenterImage "../images/stackoverflow-topframeworks-2019.jpg" false
    |> putCenterText "함수형이면서 닷넷 코어에서 돌아가는 언어는?"
    |> addSequentialShapeAnimation
    |> endSlide pptx

  static member Add pptx =
    let grp = BigWave () :> SlideGroup
    grp.Add pptx

  interface SlideGroup with
    member __.Add pptx =
      pptx
      |> title
      |> bigWave
      |> developerSurvey
      |> resultOne
      |> janeStreet
      |> piLab
      |> resultTwo

