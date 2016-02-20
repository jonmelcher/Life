// *************************************************************
//  filename:   LifeUI.cs
//  purpose:    contains a GUI for playing Conway's Game of Life
//
//  written by Jonathan Melcher
//  last updated 02/20/2016
// *************************************************************


using System;
using System.Drawing;
using System.Windows.Forms;


namespace Life
{
    // *************************************************************************
    //  class   -       public class LifeUI : Form
    //  purpose -       provides a WinForm GUI for playing Conway's Game of Life
    //  API     -       LifeUI()    -   constructor -   O(1)
    // *************************************************************************
    public partial class LifeUI : Form
    {
        private const int GRID_BUTTON_DIMENSION_PX = 25;
        private const int GRID_DIMENSION_PX = 450;
        private const int GRID_DIMENSION_CELLS = GRID_DIMENSION_PX / GRID_BUTTON_DIMENSION_PX;

        private static readonly Color ALIVE_CELL_COLOUR = Color.White;
        private static readonly Color DEAD_CELL_COLOUR = Color.DarkGray;

        private Life engine = null;

        // constructor
        // initializes WinForm application and sets up new engine
        public LifeUI()
        {
            InitializeComponent();
            engine = new Life(GRID_DIMENSION_CELLS, GRID_DIMENSION_CELLS);
        }

        // method - handles form's load event
        // dynamically creates and assigns click handlers to buttons which will act 1-1 with the cells in the engine
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

        // method - handles internal timer tick event
        // brings engine to next state and updates UI
        private void timer_Tick(object sender, EventArgs e)
        {
            engine.Tick();
            generationUI.Text = engine.Ticks.ToString();
            UpdateColours();
        }

        // method - handles click event for 'Start' button
        // starts internal timer
        private void startUI_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            startUI.Enabled = false;
            stopUI.Enabled = true;
        }

        // method - handles click event for 'Stop' button
        // stops internal timer
        private void stopUI_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            stopUI.Enabled = false;
            startUI.Enabled = true;
        }

        // method - handles click event for 'Clear' button
        // stops internal timer, creates a new engine and updates UI
        private void clearUI_Click(object sender, EventArgs e)
        {
            // timer should be shut off before proceeding, ending the game
            timer.Enabled = false;
            stopUI.Enabled = false;
            startUI.Enabled = true;

            engine = new Life(engine.Height, engine.Width);
            generationUI.Text = engine.Ticks.ToString();

            UpdateColours();
        }

        // method - delegate for dynamic button (cell) click event
        // on validation of internal timer state, updates engine state and updates caller graphics
        private void ClickCell(object sender, EventArgs e)
        {
            // game must be 'stopped' in order to click cells
            if (timer.Enabled)
                return;

            // converting linear index of controls to 2D index of engine
            int buttonLinearIndex = gridUI.Controls.IndexOf(sender as Control);
            int y = buttonLinearIndex / engine.Width;
            int x = buttonLinearIndex % engine.Width;
            
            // updating game-state data and UI
            engine[y, x] = !engine[y, x];
            ((Button)sender).BackColor =  engine[y, x] ? ALIVE_CELL_COLOUR : DEAD_CELL_COLOUR;
        }

        // method - iterates through engine and adjusts colours of UI buttons (cells) to reflect
        // the current engine state
        private void UpdateColours()
        {
            for (int linearIndex = 0; linearIndex < gridUI.Controls.Count; ++linearIndex)
                gridUI.Controls[linearIndex].BackColor =
                    engine[linearIndex / engine.Width, linearIndex % engine.Width] ? ALIVE_CELL_COLOUR : DEAD_CELL_COLOUR;
        }
    }
}