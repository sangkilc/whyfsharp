module MyPPTX.PPTHelper

open System.IO
open Syncfusion.Presentation

let createSlides () = Presentation.Create ()

let addSlide (pptx: IPresentation) layout =
  pptx.Slides.Add (slideLayout = layout)

let endSlide (pptx: IPresentation) _ = pptx

let putStringToNthPlaceholder str nth (slide: ISlide) isBold =
  let shape = slide.Shapes.[nth] :?> IShape
  shape.TextBody.Text <- str
  if isBold then shape.TextBody.Paragraphs.[0].Font.Bold <- true else ()
  slide

let putTitle title slide =
  putStringToNthPlaceholder title 0 slide true

let putAuthor author slide =
  putStringToNthPlaceholder author 1 slide false

let animate shape effType subType triggerType buildType (slide: ISlide) =
  let sequence = slide.Timeline.MainSequence
  sequence.AddEffect (shape, effType, subType, triggerType, buildType)

let animateOnClick shape effType subType buildType slide =
  animate shape effType subType EffectTriggerType.OnClick buildType slide

let animateAsOneObjOnClick shape effType subType slide =
  animateOnClick shape effType subType BuildType.AsOneObject slide

let animateByPara1OnClick shape effType subType slide =
  animateOnClick shape effType subType BuildType.ByLevelParagraphs1 slide

let animateWithPrev shape effType subType buildType slide =
  animate shape effType subType EffectTriggerType.WithPrevious buildType slide

let animateAsOneObjWithPrev shape effType subType slide =
  animateWithPrev shape effType subType BuildType.AsOneObject slide

let appearOnClick shape slide =
  animateAsOneObjOnClick shape EffectType.Appear EffectSubtype.None slide

let appearWithPrev shape slide =
  animateAsOneObjWithPrev shape EffectType.Appear EffectSubtype.None slide

let disappearWithPrev shape slide =
  let e = appearWithPrev shape slide
  e.PresetClassType <- EffectPresetClassType.Exit

let putImage path left top width height doAnimation (slide: ISlide) =
  use s = new FileStream (path, FileMode.Open)
  let pic = slide.Pictures.AddPicture (s, left, top, width, height) :?> IShape
  if doAnimation then appearOnClick pic slide |> ignore else ()
  slide

let putMaxImage path doAnimation (slide: ISlide) =
  putImage path 0.0 143.0 960.0 384.0 doAnimation slide

let putCenterImage path doAnimation (slide: ISlide) =
  putImage path 60.0 143.0 840.0 384.0 doAnimation slide

let putFittingTextBox txt alignment top height (slide: ISlide) =
  let shape = slide.Shapes.AddTextBox (65.0, top, 830.0, height)
  let para = shape.TextBody.AddParagraph ()
  para.HorizontalAlignment <- alignment
  para.AddTextPart (txt)

let putFullTextBox txt alignment (slide: ISlide) =
  putFittingTextBox txt alignment 143.0 384.0 slide

let putCodeSnippet txt size slide =
  let part = putFullTextBox txt HorizontalAlignmentType.Left slide
  part.Font.FontSize <- size
  part.Font.FontName <- "Consolas"
  slide

let putCenterText txt (slide: ISlide) =
  let part = putFullTextBox txt HorizontalAlignmentType.Center slide
  part.Font.FontSize <- 32.0f
  slide

let putFootnote txt (slide: ISlide) =
  let part = putFittingTextBox txt HorizontalAlignmentType.Left 507.0 80.0 slide
  part.Font.FontSize <- 14.0f
  slide

let appendParagraphToContent txt (slide: ISlide) =
  let shape = slide.Shapes.[1] :?> IShape
  let para = shape.TextBody.AddParagraph ()
  para.AddTextPart txt |> ignore
  slide

let addTextAnimation (slide: ISlide) =
  let shape = slide.Shapes.[1] :?> IShape
  let sequence = slide.Timeline.MainSequence
  animateByPara1OnClick shape EffectType.Wipe EffectSubtype.Left slide |> ignore
  sequence.Remove(sequence.GetEffectsByShape(shape).[0])
  slide

let addSequentialShapeAnimation (slide: ISlide) =
  for i = 1 to slide.Shapes.Count - 1 do
    appearOnClick (slide.Shapes.[i] :?> IShape) slide |> ignore
    if i > 1 then disappearWithPrev (slide.Shapes.[i - 1] :?> IShape) slide
    else ()
  slide

let removeDefaultContent (slide: ISlide) =
  slide.Shapes.RemoveAt 1
  slide

let saveSlides name (pptx: IPresentation) =
  pptx.Save (fileName = name)
  pptx.Close ()
