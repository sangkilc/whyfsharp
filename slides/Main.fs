open MyPPTX
open MyPPTX.PPTHelper

let fillOutContents pptx =
  pptx
  |> Intro.Add
  |> FunctionalLanguage.Add
  |> ParadigmShift.Add
  |> BigWave.Add
  |> FSharp.Add

let produceFile fileName pptx =
  saveSlides fileName pptx
  0

[<EntryPoint>]
let main _argv =
  createSlides ()
  |> fillOutContents
  |> produceFile "20200113-meetup.pptx"

