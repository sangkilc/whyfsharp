namespace MyPPTX

open MyPPTX.PPTHelper
open Syncfusion.Presentation

type ParadigmShift () =

  let title pptx =
    addSlide pptx SlideLayoutType.Title
    |> putTitle "코딩 패러다임의 전환"
    |> endSlide pptx

  let newLanguage pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "C스타일 언어에서 함수형언어로 ..."
    |> appendParagraphToContent "C스타일언어: Java, C++, C#, Python, Perl, 등등"
    |> appendParagraphToContent "함수형언어: Erlang, Haskell, Clojure, 등등"
    |> endSlide pptx

  let newAbility pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "뇌의 변화: 함수적 사고"
    |> appendParagraphToContent "변화된 C언어 코딩 스타일"
    |> appendParagraphToContent
      "내가 짠 코드의 문법은 C언어인데, 뭔가 함수형처럼 생겼다.."
    |> appendParagraphToContent "나의 뇌는 함수적 사고를 하고 있다!"
    |> addTextAnimation
    |> endSlide pptx

  let badExample pptx =
    let example = """function updateBinInfo(_status, str) {
  let filepath;
  const token = str.split("/");
  if (str.length < 42) {
    filepath = str;
  } else {
    for (let t in token) {
      if (token.slice(t).join("/").length < 42) {
        filepath = ".../" + token.slice(t).join("/");
        break;
      }
    }
  }
  if (filepath === undefined) {
    filepath = str.split("/").slice(str.split("/").length - 1);
  }
  $("#js-bininfo").text(filepath);
  $("#js-bininfo").attr("title", str);
}
"""
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "일반 프로그래머가 짠 프로그램 (JavaScript)"
    |> removeDefaultContent
    |> putCodeSnippet example 15.0f
    |> endSlide pptx

  let goodExample pptx =
    let example = """
function abbreviateString(str, maxLen) {
  if (str.length < maxLen) return str;
  else return "... " + str.slice(str.length - maxLen + 4);
}

function updateBinInfo(_status, str) {
  $("#js-bininfo").text(abbreviateString(str, 42));
  $("#js-bininfo").attr("title", str);
}
"""
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "함수형 뇌로 다시 짠 프로그램 (JavaScript)"
    |> removeDefaultContent
    |> putCodeSnippet example 15.0f
    |> endSlide pptx

  let lookOfCode pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "코드의 관상이 바뀌었다"
    |> appendParagraphToContent "우아한 관상의 코드"
    |> appendParagraphToContent
      "함수적 사고를 통해 함수의 본질과 의미를 다시 생각하게 됨"
    |> addTextAnimation
    |> endSlide pptx

  let meaningOfElegance pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "우아한 관상의 코드란?"
    |> appendParagraphToContent "짧고 (행위가 작은 단위로 나뉘어져 있고)"
    |> appendParagraphToContent
      "이해하기 쉬운 코드 (한눈에 함수의 의미를 이해할 수 있는 코드)"
    |> appendParagraphToContent "결국 \"작은 함수\"의 연결이 프로그램을 이룸!"
    |> addTextAnimation
    |> endSlide pptx

  let concurrencyForFree pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "동시성(Concurrency)은 공짜!"
    |> appendParagraphToContent "변수가 있다면, 동시 실행시 변수의 공유를 고려"
    |> appendParagraphToContent "즉, Lock이 필요하게 됨"
    |> appendParagraphToContent "Lock은 데드락과 race condition버그의 근본 원인"
    |> appendParagraphToContent "하지만 함수형에서는 근원적으로 문제가 없음!"
    |> addTextAnimation
    |> endSlide pptx

  let concurrencyExample pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "은행 예제"
    |> appendParagraphToContent "은행 계좌DB에 송금/입금/출금이 동시에 일어남"
    |> appendParagraphToContent
      "(고전적 접근) DB에 접근할 때마다 lock을 쓰는 방법"
    |> appendParagraphToContent "(함수적 접근) DB를 하나의 재귀 함수로 만들자!"
    |> addTextAnimation
    |> endSlide pptx

  static member Add pptx =
    let grp = ParadigmShift () :> SlideGroup
    grp.Add pptx

  interface SlideGroup with
    member __.Add pptx =
      pptx
      |> title
      |> newLanguage
      |> newAbility
      |> badExample
      |> goodExample
      |> lookOfCode
      |> meaningOfElegance
      |> concurrencyForFree
      |> concurrencyExample

