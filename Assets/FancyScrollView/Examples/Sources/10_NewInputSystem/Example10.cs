/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FancyScrollView.Example10
{
    class Example10 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;

        void Start()
        {
            var items = Enumerable.Range(0, 20)
                .Select(i => new ItemData($"Cell {i}"))
                .ToArray();

            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
        }

        static Vector2 navigateUp = new Vector2(0, -1);
        static Vector2 navigateDown = new Vector2(0, 1);
        public void Navigate(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
            {
                return;
            }
            var direction = context.ReadValue<Vector2>();
            if (direction == navigateUp)
            {
                SelectPrevious();
            }
            else if (direction == navigateDown)
            {
                SelectNext();
            }
        }

        public void SelectPrevious()
        {
            scrollView.SelectPreviousCell();
        }

        public void SelectNext()
        {
            scrollView.SelectNextCell();
        }
    }
}
