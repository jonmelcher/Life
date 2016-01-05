using System;
using System.Drawing;
using System.Windows.Forms;


namespace Life
{
    public partial class LifeUI : Form
    {
        private const int GRID_BUTTON_DIMENSION_PX = 25;
        private const int GRID_DIMENSION_PX = 450;
        private const int GRID_DIMENSION_CELLS = GRID_DIMENSION_PX / GRID_BUTTON_DIMENSION_PX;

        private static readonly Color ALIVE_CELL_COLOUR = Color.White;
        private static readonly Color DEAD_CELL_COLOUR = Color.DarkGray;

        private Life engine = null;

        // constructor
        public LifeUI()
        {
            InitializeComponent();
            engine = new Life(GRID_DIMENSION_CELLS, GRID_DIMENSION_CELLS);
        }

        // loading dynamic buttons with event-handlers onto UI
        private void LifeUI_Load(object sender, EventArgs e)
        {
            for (int j = 0; j + GRID_BUTTON_DIMENSION_PX <= GRID_DIMENSION_PX; j += GRID_BUTTON_DIMENSION_PX)
                for (int i = 0; i + GRID_BUTTON_DIMENSION_PX <= GRID_DIMENSION_PX; i += GRID_BUTTON_DIMENSION_PX)
                {
                    Button newButton = new Button();
                    newButton.Size = new Size(GRID_BUTTON_DIMENSION_PX, GRID_BUTTON_DIMENSION_PX);
                    newButton.Location = new Point(i, j);
                    newButton.Click += new EventHandler(ClickCell);
                    gridUI.Controls.Add(newButton);
                }

            UpdateColours();
        }

        // timer event - calculate new game-state and update UI
        private void timer_Tick(object sender, EventArgs e)
        {
            engine.Tick();
            generationUI.Text = engine.Ticks.ToString();
            UpdateColours();
        }

        // Start button is clicked - start timer
        private void startUI_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        // Stop button is clicked - stop timer
        private void stopUI_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        // clear button is pressed - resets properties and game to their initial states
        private void clearUI_Click(object sender, EventArgs e)
        {
            // timer should be shut off before proceeding, ending the game
            timer.Enabled = false;

            engine = new Life(engine.Height, engine.Width);
            generationUI.Text = engine.Ticks.ToString();

            UpdateColours();
        }

        // event-handler subscribed to by each cell on the UI grid
        private void ClickCell(object sender, EventArgs e)
        {
            // game must be 'stopped' in order to click cells
            if (timer.Enabled)
                return;

            // converting linear index of controls to 2D index of engine
            int buttonLinearIndex = gridUI.Controls.IndexOf(sender as Control);
            int y = buttonLinearIndex / engine.Width;
            int x = buttonLinearIndex % engine.Width;
            
            // Updating game-state data and UI
            engine[y, x] = !engine[y, x];
            ((Button)sender).BackColor =  engine[y, x] ? ALIVE_CELL_COLOUR : DEAD_CELL_COLOUR;
        }

        // update UI grid to reflect engine grid
        private void UpdateColours()
        {
            for (int linearIndex = 0; linearIndex < gridUI.Controls.Count; ++linearIndex)
                gridUI.Controls[linearIndex].BackColor =
                    engine[linearIndex / engine.Width, linearIndex % engine.Width] ? ALIVE_CELL_COLOUR : DEAD_CELL_COLOUR;
        }
    }
}