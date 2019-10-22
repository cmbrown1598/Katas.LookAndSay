namespace Katas

open System.Text

type Item = { Char : char; Count : int }

module LookAndSay = 
    let breakString (str : string) = 
        let l = String.length str
        if l = 1 then seq { yield { Char = str.[0]; Count = 1} }
        else        
            seq {    
                let mutable count =0           
                for m in 0..(l - 1) 
                    do
                        if m + 1 = l then 
                            yield { Char = str.[m]; Count = count + 1; }
                        else if (str.[m] = str.[m + 1]) then
                            count <- count + 1
                        else if (str.[m] <> str.[m + 1]) then
                            count <- count + 1
                            yield { Char = str.[m]; Count = count; }
                            count <- 0
                }



    let readOff (n: string) = 
        let sb = StringBuilder()
        for m in (breakString n)
            do
                sb.Append ( m.Count ) |> ignore
                sb.Append  (m.Char)  |> ignore
        sb.ToString()
   
    let generateLookAndSay (startWith:string) nth = 
        let rec iterate (vl:string) counter =
           match counter with 
           | n when n <= 1 -> vl
           | n -> 
                let r = iterate vl (n - 1)
                readOff r
        let first = readOff startWith
        if nth <= 1 then String.length first 
        else 

            let r = iterate first nth
            String.length r

type LookAndSayGenerator() = 
    member this.GenerateLookAndSay(str, nth) = 
        LookAndSay.generateLookAndSay str nth