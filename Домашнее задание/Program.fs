#light
open System

let rec read() =
    match System.Double.TryParse(System.Console.ReadLine()) with
    | false, _ -> printfn "Вы ввели неправильные данные. Попробуйте заново!"; read()
    | _, x -> x

printfn "А:"
let a = read();
printfn "В:"
let b = read();
printfn "С:"
let c = read();

type ResultOfSolve=
 None
    |Function of float*float

let solve = fun (a,b,c) ->
    let D = b*b-4.0*a*c
    if a=0.0 then
        if b=0.0 then None 
        else Function((-c/b),(-c/b))
    else
        if D<0.0 then None 
        else Function(((-b+sqrt(D))/(2.0*a),(-b-sqrt(D))/(2.0*a)))

let res = solve(a,b,c);

match res with
    None -> printf "Нет решений"
    |Function(x1,x2) -> printf "Уравнение имеет корни %f %f " x1 x2
System.Console.Read();