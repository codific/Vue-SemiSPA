const vmPlayground = new Vue({
    el: '#playground',
    data: {
    currentPlayer: "X",
    cells: createArray(9, null),
    currentGameState: 0,
    winner: null,
    winnerCombination: []
  },
  methods: {
    clickCell: function(row, column, event) {
        let cellIndex = ((row-1)*3) + (column-1);
        if (this.$data.cells.includes(null) && this.$data.winner == null) {
            this.$data.currentGameState++;
            this.$data.cells[cellIndex] = this.$data.currentPlayer;
            event.target.innerText = this.$data.currentPlayer;
            event.target.disabled = true;
            this.$data.currentPlayer = (this.$data.currentPlayer == "X") ? "O" : "X";
        }
    },  
    getCellValue: function(row,column) {
        return this.$data.cells[(row-1)*3 + (column-1)];
    },
    winFunction: function(winner, winnerCombination) {
        this.$data.winner = winner;
        this.$data.winnerCombination = winnerCombination;
    }
  },
  watch: {
    currentGameState: function(newVal, oldVal) {
        axios.post('/check-game-status', {
          playground: this.$data.cells
        })
        .then(function (response) {
          if (response.data != null) {
            let winnerSign = response.data.winnerSign;
            let winnerCombination = response.data.winnerCombination;
            vmPlayground.winFunction(winnerSign, winnerCombination);
          }
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  },
  mounted: function() {
      console.log("Are you ready to play?");
  }
})
