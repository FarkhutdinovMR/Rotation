using Models;
using System;

namespace Presenter
{
    public class TransformablePresenter
    {
        private readonly Transformable _model;
        private readonly RotationView _view;

        public TransformablePresenter(Transformable rotation, RotationView rotationView)
        {
            if (rotation == null)
                throw new ArgumentNullException(nameof(rotation));

            if (rotationView == null)
                throw new ArgumentNullException(nameof(rotationView));

            _model = rotation;
            _view = rotationView;
        }

        public void OnEnable()
        {
            _model.Transformated += _view.Rotate;
            _model.Ended += _view.EnablePhysics;
        }

        public void OnDisable()
        {
            _model.Transformated -= _view.Rotate;
            _model.Ended -= _view.EnablePhysics;
        }
    }
}