package mypackages

import (
	"bufio"
	"fmt"
	"log"
	"math/rand"
	"os"
	"strconv"
	"strings"
	"time"
)

// PlayGame function
func PlayGame() {
	seconds := time.Now().Unix()
	rand.Seed(seconds)
	target := rand.Intn(1000) + 1
	success := false

	fmt.Println("I've chosen a random number between 1 and 1000")
	fmt.Println("Can you guess it?")
	for guesses := 0; guesses < 10; guesses++ {
		fmt.Println("You have", 10-guesses, "tries")
		reader := bufio.NewReader(os.Stdin)
		input, err := reader.ReadString('\n')
		if err != nil {
			log.Fatal(err)
		}

		input = strings.TrimSpace(input)
		guess, err := strconv.Atoi(input)
		if err != nil {
			log.Fatal(err)
		}

		if guess < target {
			fmt.Println("Oops. Your guess was LOW")
		} else if guess > target {
			fmt.Println("Oops. Your guess was HIGH")
		} else {
			success = true
			fmt.Println("Good job! You guessed it!")
			break
		}
	}

	if !success {
		fmt.Println("Sorry. You didn't guess my number. It was: ", target)
	}
}
