namespace MyPPTX

open MyPPTX.PPTHelper
open Syncfusion.Presentation

type FunctionalLanguage () =

  let title pptx =
    addSlide pptx SlideLayoutType.Title
    |> putTitle "OCaml과의 만남"
    |> endSlide pptx

  let theManual pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "OCaml 메뉴얼 제1장 / 700+쪽"
    |> appendParagraphToContent "장난?"
    |> appendParagraphToContent "1 + 2 * 3 = ?"
    |> appendParagraphToContent "1.0 * 2 = ?"
    |> appendParagraphToContent "값, 값, 값, ..."
    |> addTextAnimation
    |> endSlide pptx

  let values pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "값?"
    |> appendParagraphToContent "let x = 값"
    |> appendParagraphToContent "그 흔한 \"변수\"도 안보이네?"
    |> appendParagraphToContent "제어문은 어디있지?"
    |> addTextAnimation
    |> endSlide pptx

  let assignments pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "변수는 매우 특별한 것"
    |> appendParagraphToContent "ref 키워드를 사용해서 선언함."
    |> appendParagraphToContent "자주 쓰지 말 것!"
    |> appendParagraphToContent "그럼 변수 없이 루프를 어떻게?"
    |> appendParagraphToContent "루프(반복) 없이 프로그래밍을 하라!"
    |> addTextAnimation
    |> endSlide pptx

  let recursion pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "답은 재귀(Recursion)"
    |> appendParagraphToContent "처치-튜링 명제 (Church-Turing Thesis)"
    |> appendParagraphToContent "모든 계산 가능한 함수는 재귀적이다."
    |> addTextAnimation
    |> endSlide pptx

  let commonMythAboutRecursion pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "재귀에 대한 오해"
    |> appendParagraphToContent "재귀는 느리다."
    |> appendParagraphToContent "재귀는 메모리 문제를 일으킨다. 지양할 것!"
    |> addTextAnimation
    |> endSlide pptx

  let recursionExample pptx =
    let example = """
def rev(str):
  arr = []
  for i in range(len(str) - 1, -1, -1):
    arr += str[i];
  return "".join(arr)
"""
    let example2 = """
def rev(str):
  if len(str) == 0:
    return ""
  else:
    return str[len(str) - 1] + rev(str[:-1])
"""
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "모든 계산을 재귀로 ... (No 변수)"
    |> removeDefaultContent
    |> putCodeSnippet example 22.0f
    |> putCodeSnippet example2 22.0f
    |> addSequentialShapeAnimation
    |> endSlide pptx

  let divideAndConquer pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "재귀의 핵심 가치?"
    |> appendParagraphToContent "반복문: 문제를 있는 그대로 풀기"
    |> appendParagraphToContent "재귀: 문제를 작은 단위로 쪼개서 풀기"
    |> appendParagraphToContent
      "문제를 작게 쪼개서 보는 능력은 유능한 프로그래머의 필수 덕목!"
    |> addTextAnimation
    |> endSlide pptx

  let recursionExample2 pptx =
    let example = """def traverse(dir):
  queue = [dir]
  result = []
  while (not queue):
    dir = queue[0]
    queue = queue[1:]
    for e in toList(dir):
      if os.path.isdir(e):
        queue.append(e)
      else:
        if isDocx(e):
          result.append(e)
  return result
"""
    let example2 = """def aux(elms):
  if len(elms) == 0: return []
  e = elms[0]
  if os.path.isdir(e): return traverse(e) + aux(elms[1:])
  else: return ([e] if isDocx(e) else []) + aux(elms[1:])

def traverse(dir):
  return aux(toList(dir))
"""
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "모든 계산을 재귀로 ... (2)"
    |> removeDefaultContent
    |> putCenterText
      "임의의 디렉토리에서\n하위 디렉토리를 포함한 모든 파일 중 docx문서를 찾기"
    |> putCodeSnippet example 22.0f
    |> putCodeSnippet example2 22.0f
    |> addSequentialShapeAnimation
    |> endSlide pptx

  let aboutElegance pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "재귀형(함수형) 코드의 미학"
    |> appendParagraphToContent "복잡한 계산을 작은 코드로"
    |> appendParagraphToContent "프로그램 = 작고 이해하기 쉬운 함수들의 집합"
    |> addTextAnimation
    |> endSlide pptx

  let codeShape pptx =
    addSlide pptx SlideLayoutType.TitleAndContent
    |> putTitle "코드의 관상: 반복문 vs. 함수형"
    |> putMaxImage "../images/codeshape.jpg" true
    |> endSlide pptx

  static member Add pptx =
    let grp = FunctionalLanguage () :> SlideGroup
    grp.Add pptx

  interface SlideGroup with
    member __.Add pptx =
      pptx
      |> title
      |> theManual
      |> values
      |> assignments
      |> recursion
      |> commonMythAboutRecursion
      |> recursionExample
      |> divideAndConquer
      |> recursionExample2
      |> aboutElegance
      |> codeShape
