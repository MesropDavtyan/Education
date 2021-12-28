package main

import (
	"errors"
	"fmt"
	"go_tutorial/mypackages"
	"log"
)

func paintNeeded(width float64, height float64) (float64, error) {
	if width < 0 || height < 0 {
		return 0, errors.New("Negative parameter")
	}
	area := width * height
	return area / 10, nil
}

func main() {
	mypackages.PlayGame()

	amount, err := paintNeeded(4.2, 3)
	if err != nil {
		log.Fatal(err)
	}
	fmt.Printf("%.2f liters needed\n", amount)

	var amountPointer *float64 = &amount
	amountValue := *amountPointer
	fmt.Printf("Amount points to: %p\nAmount value is: %.2f\n", amountPointer, amountValue)
}
